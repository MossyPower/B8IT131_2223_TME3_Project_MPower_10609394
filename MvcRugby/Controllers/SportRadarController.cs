using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcRugby.Models;
using MvcRugby.Mappings;
using MvcRugby.ViewModels;
using MvcRugby.Services;
using MvcRugby.Mappings;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace MvcRugby.Controllers
{
    // [Authorize]
    public class SportRadarController : Controller
    {       
        //Create an instance of the SportRadarApiService class
        private readonly ILogger<SportRadarController> _logger;
        private readonly SportRadarApiService _sportRadarApiService;
        private readonly RugbyDataApiService _rugbyDataApiService;

        public SportRadarController(ILogger<SportRadarController> logger, SportRadarApiService sportRadarApiService, RugbyDataApiService rugbyDataApiService)
        {
            _logger = logger;
            _sportRadarApiService = sportRadarApiService;
            _rugbyDataApiService = rugbyDataApiService;
        }
        
        // URI: http://localhost:5254/SportRadar/Season
        
        public IActionResult Index()
        {
            return View();
        }
        
        // Sync Sport Radar Api data with local Rugby Data Api
        public async Task<IActionResult> SyncSeasonsEndPoint()
        {
            // Not passsing in anything as button acts as trigger only, all logic occurs here

            var seasonInfo = await _sportRadarApiService.GetSeasons();
            
            //DateTime startDate = new DateTime(2024, 05, 01); //pass as parameter?

            var newSeasons = new List<Season>();

            // var season = new Season
            // {
            //     Id = "3",
            //     name = "Test3",
            //     start_date = new DateTime(2024, 1, 3),
            //     end_date = "2023-01-03",
            //     year = "23/24",
            //     competition_Id = "2",
            // };    

            foreach(var season in seasonInfo.seasons)
            {
                //if(season.start_date >= startDate)
                //{
                    newSeasons.Add(season);
                //}
            }
            
            _logger.LogInformation($"Number of seasons: {newSeasons.Count()}");
            
            if(newSeasons != null)
            {
                // Deserialize the season object to JSON for logging
                //var seasonJson = JsonConvert.SerializeObject(season);
                //_logger.LogInformation($"Season JSON: {seasonJson}");
                
                foreach(var season in newSeasons)
                {
                    await _rugbyDataApiService.SaveSeasons(season);
                }
                return RedirectToAction("Index");    
            }    
            else
            {
                _logger.LogWarning("The 'seasons' object is null in SaveSeasons method.");
                return BadRequest();
            }
            

            //await SaveSeasons(seasonInfo);         
            
            //return Ok();

            // try
            // {
            //     // Fetch the data from Sport Radar Api Endpoint
            //     var seasons = await _sportRadarApiService.GetSeasons();

            //     // Log the received seasons data
            //     _logger.LogInformation("Received seasons data: {@Seasons}", seasons);

            //     // Save data retrieved from Sport Radar API to Rugby Data Api (pass to seperate method below as parameter to complete task)
            //     await SaveSeasons(seasons);

            //     // Return appropriate result
            //     return Ok(); // Replace with the appropriate result based on your requirements
            // }
            // catch (NullReferenceException ex)
            // {
            //     // Log the exception details
            //     _logger.LogError(ex, "An error occurred in SyncSeasonsEndPoint");

            //     // Return an error response or handle it as needed
            //     return StatusCode(500, "Internal Server Error");
            // }
        }
        
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // private async Task SaveSeasons(SeasonInfo seasons)
        // {
        //     try
        //     {               
        //         // Check if 'seasons' is null before processing
        //         if (seasons == null)
        //         {
        //             _logger.LogWarning("The 'seasons' object is null in SaveSeasons method.");
        //             return;
        //         }

        //         _logger.LogInformation($"Number of seasons: {seasons.seasons?.Count ?? 0}");

        //         // Check if 'seasons' is not null and 'seasons.seasons' is not null
        //         // if (seasons.seasons != null)
        //         // {
        //             //foreach (var season in seasons.seasons)
        //             //{
        //                 // Ensure that each season and its properties are not null before processing
        //                 // if (season != null && !string.IsNullOrEmpty(season.Id) && !string.IsNullOrEmpty(season.name))
        //                 // {
        //                     // Deserialize the season object to JSON for logging
        //                     var seasonJson = JsonConvert.SerializeObject(seasons);
        //                     _logger.LogInformation($"Season JSON: {seasonJson}");

        //                     // Save the season
        //                     await _rugbyDataApiService.SaveSeasons(seasons);
        //                 // }
        //                 // else
        //                 // {
        //                     _logger.LogError("A season or its properties within 'seasons.seasons' is null or empty in SaveSeasons.");
        //                 // }
        //             //}
        //         // }
        //         // else
        //         // {
        //         //     _logger.LogError("The 'seasons.seasons' is null in SaveSeasons.");
        //         // }

        //         _logger.LogInformation("Seasons processing completed successfully");
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "An error occurred in SaveSeasons.");
        //     } 
        // }

        // **********
        // Sync Sport Radar Season Players Endpoint
        public async Task<IActionResult> SyncSeasonPlayersEndPoint() //Pass SportRadar Competition Id as a parameter
        {
            // fetch the information from the Sport Radar Api
            var playerInfo = await _sportRadarApiService.GetPlayersBySeasonId("sr:competition:419");
            
            // 
            var newPlayers = new List<SeasonPlayer>();
            
            foreach(var player in playerInfo.SeasonPlayers)
            {
                newPlayers.Add(player);
            }
                _logger.LogInformation($"Number of players: {newPlayers.Count()}");
                        
            if(newPlayers != null)
            {
                foreach(var player in newPlayers)
                {
                    await _rugbyDataApiService.SavePlayers(player);
                }
                
                return RedirectToAction("Index");    
            }    
            else
            {
                _logger.LogWarning("The 'players' object is null in the SavePlayers method.");
                
                return BadRequest();
            }
        }

        // **********
        public async Task<IActionResult> Competitions()
        {
            // Get SportsRadar data from Api via services
            var competitions = await _sportRadarApiService.GetSeasons();
            
            // Check to see if data returned from API
            if (competitions != null)
            {
                // New instance of the CompetitionViewModel
                var ViewModel = new CompetitionsViewModel();

                if (competitions != null)
                {
                    ViewModel.Seasons = competitions?.seasons? // initialise ViewModel with the info from mappings.SeasonInfo.seasons
                        .Where(season => DateTime.TryParse(season.end_date, out var endDate) && endDate >= DateTime.Today) // where the seasons end date is the same or later than todays date
                        .Select(season => new SeasonViewModel { Name = season.name, Id = season.Id }) // the info to initialise: name and ID
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
            var CompetitionRounds = await _sportRadarApiService.GetSrSeasonLineups(id);
            
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
            var roundLineup = await _sportRadarApiService.GetSrSeasonLineups(id);

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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}