using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Mappings;
using MvcRugby.ViewModels;
using MvcRugby.Services;
using System.Net;

namespace MvcRugby.Controllers
{
    //[Authorize]
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
                    //StartDate = group.First()Start_Time,
                    //EndDate = group.First().sport_event?.start_time_confirmed ?? false
                })
                .ToList()
            };
            return View(ViewModel);
        }

        // Get: All fixtures for a given round (which includes teams), All players, All player statistics, 
        public async Task<IActionResult> RoundFixtures(int id, int roundNumber)
        {
            // 1. Get all competitions
            var competition = await _rugbyDataApiService.GetCompetitionById(id);      

            // 2. Get all fixtures by per round
            var fixtures = await _rugbyDataApiService.GetCompetitionFixtures(id);
            var roundFixtures = fixtures.Where(f => f.RoundNumber == roundNumber); // gets a list of competition fixtures, filtered by round number (e.g. all fixtures for the URC, round 1)

            // 3. Get a list of Team Lineups for each round fixture (two teams per fxture)
            var teamLineups = new List<TeamLineup>(); //new empty list
            
            foreach(var fixture in roundFixtures) // for each fixture in the list of roundFixtures
            {
                var fixtureId = fixture.FixtureId; // get the FixtureId

                var teamLineup = await _rugbyDataApiService.GetTeamLineupById(fixtureId); //Get TeamLineups by FixtureId

                teamLineups.Add(teamLineup); //Add the TeamLineup returned to the list
            }
            
                        
            // 4. Get a list of all Player Lineups for each Team Lineup (2x player lineups per team)
            // var playerLineups = new List<PlayerLineup>(); //new empty list
            
            // foreach(var player in teamLineups) // for each fixture in the list of roundFixtures
            // {
            //     var playerId = player.PlayerLineups; // get the FixtureId

            //     var teamLineup = await _rugbyDataApiService.GetTeamLineupById(fixtureId); //Get TeamLineups by FixtureId

            //     teamLineups.Add(teamLineup); //Add the TeamLineup returned to the list
            // }
            
            
            
            
            
            
            
            
            
            
            
            
            var ViewModel = new ComparisonViewModel()
            {
                CompetitionId = id,
                CompetitionName = competition.CompetitionName, // get competition name               
                RoundNumber = roundNumber,
                Fixtures = roundFixtures.ToList(),

            };

            return View(ViewModel);
        }
    }
}