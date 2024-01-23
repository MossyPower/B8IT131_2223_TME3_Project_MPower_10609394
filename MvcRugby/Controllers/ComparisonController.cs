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
            var compFixtures = await _rugbyDataApiService.GetAllFixturesByCompetitionId(id);

            var ViewModel = new RoundsViewModel()
            {
                
                CompetitionName = competition.Competition_Name, 
                CompetitionId = id,
                // RoundsViewModel Attribute = Competition Model Attribute path
                // Group By method: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby?view=net-8.0 : 
                // 'GroupBy' returns sequence of IGrouping<TKey, TElement> where TKey is the key and TElement is the type of elements within each group. 
                Rounds = compFixtures
                .GroupBy(item => item.Round_Number)
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
            // Get all competitions
            var competition = await _rugbyDataApiService.GetCompetitionById(id);      
            
            // Get all fixtures by per round
            var fixtures = await _rugbyDataApiService.GetAllFixturesByCompetitionId(id);
            var roundFixtures = fixtures.Where(f => f.Round_Number == roundNumber);// get all competition fixtures, filtered by round number
            
            // Filter the returned fixtures by CompetitionId 
            //      For the URC, total fixtures = 18 rounds x 9 fixtures per round = 162 + 7 knock-out fixtures = total 169 fixtures to filter by round
            //      Similar-ish for other comps
            //      Need to look at completing this by querying Db in RugbyDataApi instead of completing this in-memory, passing two params
            var ViewModel = new ComparisonViewModel()
            {
                CompetitionId = id,
                Competition_Name = competition.Competition_Name, // get competition name               
                Round_Number = roundNumber,
                Fixtures = roundFixtures.ToList(),
                FixtureStatistics = null,
                Players = null,
            };
            return View(ViewModel);
        }
    }
}