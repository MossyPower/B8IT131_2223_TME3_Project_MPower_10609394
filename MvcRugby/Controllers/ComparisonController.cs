using Microsoft.AspNetCore.Mvc;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.ViewModels;
using MvcRugby.Services;

namespace MvcRugby.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly ILogger<ComparisonController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public ComparisonController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory, ILogger<ComparisonController> logger)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
            _logger = logger;
        }
        
        //Get: All Competitions
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllCompetitions());
        }
        

        //Get: All fixtures in a given Competition, group by round
        public async Task<IActionResult> Rounds(int id)
        {
            var competition = await _rugbyDataApiService.GetCompetitionById(id);
            var compFixtures = await _rugbyDataApiService.GetCompetitionFixtures(id);

            var ViewModel = new RoundsViewModel()
            {
                
                CompetitionName = competition.CompetitionName, 
                CompetitionId = id,
                // RoundsViewModel Attribute = Competition Model Attribute path
                // Group By method: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby?view=net-8.0 : 
                // 'GroupBy' returns sequence of IGrouping<TKey, TElement> where TKey is the key and TElement is the type of elements within each group. 
                Rounds = compFixtures
                .GroupBy(item => item.RoundNumber)
                .Select(group => new RoundInfoViewModel //each item in the list is an instance of the RoundsViewModel (within the CompRoundsViewModel) 
                {
                    RoundNumber = group.Key, // Group key is the round number
                    Status = group.First().Status
                })
                .ToList()
            };
            return View(ViewModel);
        }

        // Get: All fixtures for a given round (which includes teams), All players, All player statistics, 
        public async Task<IActionResult> RoundFixtures(int id, int roundNumber)
        {
            // 1. FETCH ALL DATA FROM THE RUGBY DATA API
            
            // 1.1. Get Competition data, by CompetitionId
            var competition = await _rugbyDataApiService.GetCompetitionById(id);      

            // 1.2. Get all Fixtures data for this round, by FixtureId and RoundNumber
            var fixtures = await _rugbyDataApiService.GetRoundFixtures(id, roundNumber);

            // 1.3. get all TeamLineups by for each fixture, fixtureId
            var allFixtureIds = new List<int>();
            foreach (var fixture in fixtures)
            {
                allFixtureIds.Add(fixture.FixtureId);
            }           
            var teamLineups = await _rugbyDataApiService.GetRoundTeamLineups(allFixtureIds);

            // 1.4(alternate) Get a list of playerLineups for each teamlineupId, then order by Jersey number
            var roundPlayerLineups = new List<List<PlayerLineup>>();
            foreach (var teamLineup in teamLineups)
            {
                var playerLineup = await _rugbyDataApiService.GetPlayerLineupByTeamLineupId(teamLineup.TeamLineupId); // will make 16 calls for a typical URC round (16 teams)

                //add each playerLineup list returned to the roundPlayers list, & order by JerseyNumber
                roundPlayerLineups.Add(playerLineup.OrderBy(player => player.JerseyNumber).ToList()); //List of Lists
            }

            // 1.5 Get a list of Teams, for each teamLineupId 
            var allTeamIds = new List<int>(); //list of lists needed
            foreach(var team in teamLineups)
            {
                allTeamIds.Add(team.TeamId);
            }
            var teams = await _rugbyDataApiService.GetRoundTeams(allTeamIds);

            // 1.6(Alternate)
            // get an outer list of all players per team            
            var roundPlayers = new List<List<Player>>();
            foreach(var playerLineupList in roundPlayerLineups) //first access the list of lists
            {
                var roundPlayersIds = new List<int>(); // create a list to hole playerIds the team
                foreach(var player in playerLineupList) //next access each playerLineup in inner list, add the player Id to the allPlayerIds2 variable 
                {
                    roundPlayersIds.Add(player.PlayerId);
                }              
                if(roundPlayersIds.Any())
                {
                    var teamPlayers = await _rugbyDataApiService.GetRoundPlayers(roundPlayersIds);
                    //add each playerLineup list returned to the roundPlayers list, & order by JerseyNumber
                    roundPlayers.Add(teamPlayers.ToList()); //List of Lists
                }
            }

            // 2. ADD ALL RELEVANT DATA TO THE VIEW MODEL
            var ViewModel = new ComparisonViewModel()
            {
                // dont think this is required?
                CompetitionId = id,
                
                // display competition name at top of view
                CompetitionName = competition.CompetitionName,             
                
                // display round number at top of view
                RoundNumber = roundNumber, 
                
                // dont think this is required?
                Fixtures = fixtures.ToList(),
                
                // dont think this is required?
                TeamLineups = teamLineups.ToList(),
                
                // dont think this is required?
                PlayerLineups = roundPlayerLineups.ToList(),
                              
                // display all round team names in table headers
                Teams = teams.ToList(),
                
                // display all player names for each team in each table column header (for each position)
                Players = roundPlayers.ToList(),

                // display all player statistics under each player name in a table column
                PlayersStatistics = null,
            };

            return View(ViewModel);
        }
    }
}