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
        
        // Sync Sportradar Competition Players Endpoint - 50% complete: TeamId restriction needs to be resolved
        public async Task<IActionResult> SyncSeasonPlayersEndPoint(string id) //Pass SportRadar Competition Id as a parameter
        {
            // fetch the information from the Sport Radar Api, parameter required is Sportradar Competition Id
            var playerInfo = await _sportRadarApiService.GetSrSeasonPlayers("sr:competition:419"); //manualy include parameter to test
            
            // new empty list to transfer each player from Sportradar mapping to local Api model
            var newPlayers = new List<Player>();
            
            // transfer each player
            foreach(var player in playerInfo.SeasonPlayers)
            {
                var newPlayer = new Player()
                {
                    SrPlayerId = player.id,
                    FirstName = player.first_name,
                    LastName = player.last_name,
                    DateOfBirth = null,
                    Nationality = null,
                    //TeamId = null, => Required, foreign key... [Sportradar endpoint does not include player team info]
                };               
                
                // add each new player to the newPlayers list
                newPlayers.Add(newPlayer);
            }
            // check how many (if any) players were added
            _logger.LogInformation($"Number of players: {newPlayers.Count()}");

            // check if the newPlayers list is null      
            if(newPlayers != null)
            {
                // add each new player to the Api Db
                foreach(var player in newPlayers)
                {
                    await _rugbyDataApiService.AddPlayer(player);
                }
                return RedirectToAction("Index");    
            }    
            else
            {
                _logger.LogWarning("The 'players' object is null in the SavePlayers method.");
                
                return BadRequest();
            }
        }
          
        // Sync Sportradar Season Teams Endpoint - 80% Complete: update Api to stop duplicate entries 
        public async Task<IActionResult> SyncSeasonTeamsEndPoint(string id) //Pass SportRadar Season Id as a parameter
        {
            // fetch the information from the Sport Radar Api, parameter required is Sportradar Season Id, update Db for Sr Season Id as well as Sr Competition Id
            var srCompetitionTeams = await _sportRadarApiService.GetSrSeasonCompetitors("sr:season:106497");
            
            // new empty list to transfer each team from Sportradar mapping to local Api model
            var newTeams = new List<Team>();
            
            // transfer each player
            foreach(var team in srCompetitionTeams.Season_Competitors)
            {
                var newTeam = new Team()
                {
                    SrCompetitorId = team.id,
                    TeamName = team.name,
                    Country = null,
                };
                
                // add each new player to the newPlayers list
                newTeams.Add(newTeam);
            }
            // check how many (if any) players were added
            _logger.LogInformation($"Number of players: {newTeams.Count()}");

            // check if the newPlayers list is null      
            if(newTeams != null)
            {
                // add each new player to the Api Db
                foreach(var team in newTeams)
                {
                    await _rugbyDataApiService.AddTeam(team);
                }
                return RedirectToAction("Index");    
            }    
            else
            {
                _logger.LogWarning("The 'teams' object is null in the SavePlayers method.");
                
                return BadRequest();
            }
        }

        // Sync Sportradar Season Lineup Endpoint - 80% Complete: update Api to stop duplicate entries 
        public async Task<IActionResult> SyncCompetitionLineup(int competitionId, string srSeasonId) //Pass SportRadar Season Id as a parameter
        {
            _logger.LogInformation($"SyncCompetitionLineup action method called, retriving Sportradar Season Lineups using action method 'GetSrSeasonLineups'");
            
            // fetch the information from the Sport Radar Api, parameter required is Sportradar Season Id
            var srCompetitionFixtures = await _sportRadarApiService.GetSrSeasonLineups("sr:season:106497"); //sr:season:106497
            
            // new empty list to transfer each team from Sportradar mapping to local Api model
            var newFixtures = new List<Fixture>();
            
            // transfer each player
            foreach(var sportEvent in srCompetitionFixtures.lineups)
            {
                var newFixture = new Fixture()
                {
                    SrSportEventId = sportEvent.sport_event.id,
                    RoundNumber = sportEvent.sport_event.sport_event_context.round.number,
                    StartTime = sportEvent.sport_event.start_time,
                    Status = sportEvent.sport_event_status.status,
                    HomeScore = sportEvent.sport_event_status.home_score,
                    AwayScore = sportEvent.sport_event_status.away_score,
                    CompetitionId = competitionId,
                };
                
                // add each new player to the newPlayers list
                newFixtures.Add(newFixture);
            }
            // check how many (if any) players were added
            _logger.LogInformation($"Number of fixtures: {newFixtures.Count()}");

            // check if the newPlayers list is null      
            if(newFixtures != null)
            {
                if(ModelState.IsValid)
                {
                    // add each new player to the Api Db
                    foreach(var fixture in newFixtures)
                    {
                        _logger.LogInformation($"Fixture data being posted: {Newtonsoft.Json.JsonConvert.SerializeObject(fixture)}");
                        await _rugbyDataApiService.AddFixture(fixture);
                    }
                }
                return RedirectToAction("Index");    
            }    
            else
            {
                _logger.LogWarning("The 'teams' object is null in the SavePlayers method.");
                
                return BadRequest();
            }
        }
        
        public async Task<IActionResult> SyncCompetitionTeamLineups(int competitionId) //Pass SportRadar Season Id as a parameter
        {
        
            _logger.LogInformation($"***************SyncCompetitionLineup action method called, retriving Sportradar Season Lineups using action method 'GetSrSeasonLineups'");
            
            var srCompetitionFixtures = await _sportRadarApiService.GetSrSeasonLineups("sr:season:106497"); //sr:season:106497
            
            // retrieve all fixtures (including new Ids generated by the Db, add the teamlineups from theretrieved endpoint data)
            var allCompetitionFixtures = await _rugbyDataApiService.GetCompetitionFixtures(competitionId);
            _logger.LogInformation($"team lineup data: {allCompetitionFixtures}");

            var allTeams = await _rugbyDataApiService.GetAllTeams();
            _logger.LogInformation($"team lineup data: {allTeams}");

            //New teamLineupList
            var newTeamLineups = new List<TeamLineup>();
            foreach(var fixture in allCompetitionFixtures) //for a fixture
            {                
                foreach (var team in allTeams) //for a team
                {
                    foreach(var sportEvent in srCompetitionFixtures.lineups) //for each event lineup
                    {
                        foreach(var lineup in sportEvent.sport_event.competitors) //for each lineup competitor
                        {
                            if(fixture.SrSportEventId == sportEvent.sport_event.id && team.SrCompetitorId == lineup.id)
                            {
                                if(lineup.qualifier == "home")
                                {
                                    var newTeamLineup = new TeamLineup()
                                    {
                                        Designation = "home",
                                        FixtureId = fixture.FixtureId,
                                        TeamId = team.TeamId,
                                    };
                                    newTeamLineups.Add(newTeamLineup);
                                }
                                else if(lineup.qualifier == "away")
                                {
                                    var newTeamLineup = new TeamLineup()
                                    {
                                        Designation = "away",
                                        FixtureId = fixture.FixtureId,
                                        TeamId = team.TeamId,
                                    };
                                    newTeamLineups.Add(newTeamLineup);
                                }
                            }
                        }
                    }
                }
            }

            _logger.LogInformation($"Number of team Lineups: {newTeamLineups.Count()}");
            _logger.LogInformation($"team lineup data: {newTeamLineups}");

            if(newTeamLineups != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // add each new team lineup to the Api Db
                foreach(var teamLineup in newTeamLineups)
                {
                    _logger.LogInformation($"TeamLineup Data: {Newtonsoft.Json.JsonConvert.SerializeObject(teamLineup)}");

                    await _rugbyDataApiService.AddTeamLineup(teamLineup);
                }
                return RedirectToAction("Index");    
            }
            else
            {
                _logger.LogWarning("The 'teams' object is null in the SavePlayers method.");
                
                return BadRequest();
            }
        }

        // **********

        public IActionResult Index()
        {
            return View();
        }

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
                            StartTimeConfirmed = group.First().sport_event?.start_time_confirmed ?? false
                        })
                        .ToList()
                };  

                return View(ViewModel);
            }
            else
            {
                return NotFound();
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
                                    }
                                }
                                viewModel.RoundDetails.FirstOrDefault()?.Teams.Add(teamViewModel);
                            }
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