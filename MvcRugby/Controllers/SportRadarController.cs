using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MvcRugby.Models;
using MvcRugby.Services;
using MvcRugby.Mappings;
using System.Text.RegularExpressions;

namespace MvcRugby.Controllers
{
    // [Authorize]
    public class SportRadarController : Controller
    {       
        //Create an instance of the ComparisonApiService class
        private readonly SportRadarApiService _sportRadarApiService;
        
        public SportRadarController(SportRadarApiService sportRadarApiService)
        {
            _sportRadarApiService = sportRadarApiService;
        }
        
        // URI: http://localhost:5254/SportRadar/Season
        public async Task<IActionResult> Index()
        {
            // Get SportsRadar data from Api via services
            var competitions = await _sportRadarApiService.GetCompetitions();
            
            // Check to see if data returned from API
            if (competitions != null)
            {
                // New instance of the CompetitionViewModel
                var ViewModel = new CompetitionsViewModel();

                if (competitions != null)
                {
                    ViewModel.Seasons = competitions?.Sr_Seasons? // initialise ViewModel with the info from mappings.Sr_Season_Info.Sr_Seasons
                        .Where(season => DateTime.Parse(season.end_date) >= DateTime.Today) // where the seasons end date is the same or later than todays date
                        .Select(season => new SeasonViewModel { Name = season.name, Id = season.id }) // the info to initialise: name and ID
                        .ToList(); // way to initialse the data, i.e. as a list
                };
                
                return View(ViewModel); // return the initialsed viewData model
            }
            else
            {
                return NotFound(); // else return 404 error
            }
        }
        
        // URI: http://localhost:5254/SportRadar/GetSeasonLineups/sr%3Aseason%3A107205
        public async Task<IActionResult> CompRounds(string? id)
        {
            // Get SportsRadar data from Api via services, using id passed from Index() view by the user selection
            var CompetitionRounds = await _sportRadarApiService.GetCompetitionRounds(id);
            
            // Check to see if data returned from API
            if (CompetitionRounds != null)
            {
                // New instance of the CompRoundsViewModel called ViewModel
                var ViewModel = new CompRoundsViewModel()
                {
                    // Initialise the ViewModel CompetitionName attribute with the API data, using Mappings -> lineups () -> sport_event -> sport_event_context -> groups () -> name 
                    CompetitionName = CompetitionRounds?.Sr_Lineups?.FirstOrDefault()?.Sr_Sport_Event?.Sr_Sport_Event_Context?.Sr_Groups?.FirstOrDefault()?.Sr_Name, 
                    
                    // Get the season ID for the next call
                    SeasonId = CompetitionRounds?.Sr_Lineups[0]?.Sr_Sport_Event?.Sr_Sport_Event_Context?.Sr_Season?.Sr_Id,

                    // Initialise the CompRoundsViewModel list<Rounds>, with info from the Api via services, using mappings -> SeasonLineups -> List<Lineups> lineups 
                    Rounds = CompetitionRounds?.Sr_Lineups?
                        .GroupBy(item => item.Sr_Sport_Event?.Sr_Sport_Event_Context?.Sr_Round?.Sr_Number)
                        .Select(group => new RoundViewModel //each item in the list is an instance of the RoundsViewModel (within the CompRoundsViewModel) 
                        {
                            RoundNumber = group.Key ?? -1, // Group key is the round number
                            Status = group.First().Sr_Sport_Event_Status?.Sr_Status,
                            StartTime = DateTime.Parse(group.First().Sr_Sport_Event?.Sr_start_Time),
                            StartTimeConfirmed = group.First().Sr_Sport_Event?.Sr_Start_Time_Confirmed ?? false
                        })
                        .ToList()
                };  

                return View(ViewModel);
            }
            else
            {
                return NotFound(); // else return 404 error
            }
        }
        
        
        // URI: https://localhost:7286/RugbyDataApi/RoundLineup/sr%3Aseason%3A107205
        //[HttpGet("RoundLineup/{id}")]
        public async Task<IActionResult> RoundLineup(string? id)
        {
            // Get SportsRadar data from API via services, using id passed from Index() view by the user selection
            var roundLineup = await _sportRadarApiService.GetRoundLineup(id);

            // Check to see if data returned from API
            if (roundLineup != null && roundLineup.Sr_Lineups != null)
            {
                foreach (var sportEvent in roundLineup.Sr_Lineups)
                {
                    if (sportEvent?.Sr_Sport_Event?.Sr_Sport_Event_Context?.Sr_Round?.Sr_Number == 4)
                    {
                        var viewModel = new RoundLineupViewModel()
                        {
                            RoundDetails = new List<RoundDetail>
                            {
                                new RoundDetail
                                {
                                    SeasonId = sportEvent.Sr_Sport_Event?.Sr_Sport_Event_Context?.Sr_Season?.Sr_Id,
                                    CompetitionName = sportEvent.Sr_Sport_Event?.Sr_Sport_Event_Context?.Sr_Groups?.FirstOrDefault()?.Sr_Name,
                                    RoundNumber = sportEvent.Sr_Sport_Event?.Sr_Sport_Event_Context?.Sr_Round?.Sr_Number ?? -1,
                                    Teams = new List<RoundTeams>()
                                }
                            },
                            Players = null
                        };

                        // Check if there are competitors (i.e. Teams) in the lineups for the round
                        if (sportEvent.Lineups?.Sr_Sport_Event_Lineup_Competitors?.Any() == true)
                        {
                            //var tasks = new List<Task>();

                            foreach (var competitor in sportEvent.Lineups.Sr_Sport_Event_Lineup_Competitors)
                            {
                                var teamViewModel = new RoundTeams
                                {
                                    TeamId = competitor.Sr_Id,
                                    TeamName = competitor.Sr_name,
                                    Players = new List<MatchSquad>()
                                };

                                // Check if there are players in the competitor
                                if (competitor.Sr_Players != null)
                                {
                                    foreach (var player in competitor.Sr_Players)
                                    {
                                        var matchSquad = new MatchSquad
                                        {
                                            PlayerId = player.Sr_Id,
                                            PlayerName = player.Sr_Name,
                                            PlayerNumber = player.Sr_Jersey_Number ?? -1,
                                            PlayerPosition = player.Sr_Type
                                        };

                                        teamViewModel.Players.Add(matchSquad);
                                        
                                        //await Task.Delay(1000);

                                        // Collect tasks for player statistics retrieval
                                        //tasks.Add(_sportRadarApiService.GetPlayerStatistics(matchSquad.PlayerId));
                                    }
                                }
                                viewModel.RoundDetails.FirstOrDefault()?.Teams.Add(teamViewModel);
                            }

                            // Await all player statistics retrieval tasks
                            //await Task.WhenAll(tasks);
                        }

                        return View(viewModel);
                    }
                }
            }

            return NotFound();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}