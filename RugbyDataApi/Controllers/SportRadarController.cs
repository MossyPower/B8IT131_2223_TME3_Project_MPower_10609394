// This controller fetchs data from Sport Radar third-party API and stores in locally only. 
// Includes an automated background service to complete this.
// Background service restricts number of calls per second / month to comply with third-party call limits.
// This controller has no interaction with the MvcRugby App 

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using RugbyDataApi.Services;
using RugbyDataApi.Models;
using RugbyDataApi.Mappings;
using RugbyDataApi.Data;

namespace RugbyDataApi.Controllers
{
    // [Authorize]
    public class SportRadarController : Controller
    {       
        //Create an instance of the SportRadarApiService class
        private readonly RugbyDataDbContext _rugbyDataDbContext;
        private readonly SportRadarApiService _sportRadarApiService;
        
        public SportRadarController(RugbyDataDbContext rugbyDataDbContext, SportRadarApiService sportRadarApiService)
        {
            _rugbyDataDbContext = rugbyDataDbContext;
            _sportRadarApiService = sportRadarApiService;
        }
        
        // Start background service / fect & store methods here
        // Assumed one required for each end point in the Sports Radar Api, i.e.: 
        // Seasons
        // SeasonLineup
        // Players ==> this should be changed to match results
        //    ^^^^ Save each players statistics to a seperate mode in the local database

            [HttpGet]
            public async Task<IActionResult> SyncSeasons()
            {
                var seasonsFromApi = await _sportRadarApiService.GetSeasonsFromApi();

                // Save to the database
                _rugbyDataDbContext.Seasons.AddRange(seasonsFromApi);
                await __rugbyDataDbContext.SaveChangesAsync();

                return Ok("Seasons data synced successfully.");
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
                    ViewModel.Seasons = competitions?.seasons? // initialise ViewModel with the info from mappings.SeasonInfo.seasons
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
                    CompetitionName = CompetitionRounds?.lineups?.FirstOrDefault()?.sport_event?.sport_event_context?.groups?.FirstOrDefault()?.name, 
                    
                    // Get the season ID for the next call
                    SeasonId = CompetitionRounds?.lineups[0]?.sport_event?.sport_event_context?.season?.id,

                    // Initialise the CompRoundsViewModel list<Rounds>, with info from the Api via services, using mappings -> SeasonLineups -> List<Lineups> lineups 
                    Rounds = CompetitionRounds?.lineups?
                        .GroupBy(item => item.sport_event?.sport_event_context?.round?.number)
                        .Select(group => new RoundViewModel //each item in the list is an instance of the RoundsViewModel (within the CompRoundsViewModel) 
                        {
                            RoundNumber = group.Key ?? -1, // Group key is the round number
                            Status = group.First().sport_event_status?.status,
                            StartTime = DateTime.Parse(group.First().sport_event?.start_time),
                            StartTimeConfirmed = group.First().sport_event?.start_time_confirmed ?? false
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
        
        
        // URI: http://localhost:5254/SportRadar/RoundLineup/sr%3Aseason%3A107205
        //[HttpGet("RoundLineup/{id}")]
        public async Task<IActionResult> RoundLineup(string? id)
        {
            // Get SportsRadar data from API via services, using id passed from Index() view by the user selection
            var roundLineup = await _sportRadarApiService.GetRoundLineup(id);

            // Check to see if data returned from API
            if (roundLineup != null && roundLineup.lineups != null)
            {
                foreach (var sportEvent in roundLineup.lineups)
                {
                    if (sportEvent?.sport_event?.sport_event_context?.round?.number == 4)
                    {
                        var viewModel = new RoundLineupViewModel()
                        {
                            RoundDetails = new List<RoundDetail>
                            {
                                new RoundDetail
                                {
                                    SeasonId = sportEvent.sport_event.sport_event_context.season?.id,
                                    CompetitionName = sportEvent.sport_event.sport_event_context.groups?.FirstOrDefault()?.name,
                                    RoundNumber = sportEvent.sport_event.sport_event_context.round?.number ?? -1,
                                    Teams = new List<RoundTeams>()
                                }
                            },
                            Players = null
                        };

                        // Check if there are competitors (i.e. Teams) in the lineups for the round
                        if (sportEvent.lineups?.competitors?.Any() == true)
                        {
                            //var tasks = new List<Task>();

                            foreach (var competitor in sportEvent.lineups.competitors)
                            {
                                var teamViewModel = new RoundTeams
                                {
                                    TeamId = competitor.id,
                                    TeamName = competitor.name,
                                    Players = new List<MatchSquad>()
                                };

                                // Check if there are players in the competitor
                                if (competitor.players != null)
                                {
                                    foreach (var player in competitor.players)
                                    {
                                        var matchSquad = new MatchSquad
                                        {
                                            PlayerId = player.id,
                                            PlayerName = player.name,
                                            PlayerNumber = player.jersey_number ?? -1,
                                            PlayerPosition = player.type
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
    }
}