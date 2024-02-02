using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.ViewModels;
using MvcRugby.Services;

namespace MvcRugby.Controllers
{
    public class FixtureController : Controller
    {
        // Set up constructor & dependancy injection
        private readonly ILogger<FixtureController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public FixtureController(ILogger<FixtureController> logger, ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: competition season fixtures
        public async Task<IActionResult> Index(int competitionId) // CompetitionId Param
        {
            // Fetch competition data
            var competition = await _rugbyDataApiService.GetCompetitionById(competitionId);
            
            // Fetch all competition fixtures
            var competitionFixtures = await _rugbyDataApiService.GetCompetitionFixtures(competitionId);
            
            // Combine list of fixtures and associated teams
            var fixturesInfo = new List<FixtureInfo>();
            foreach(var fixture in competitionFixtures)
            {
                // Get Teamlineup using fixture Id
                var fixtureTeamLineups = await _rugbyDataApiService.GetFixtureTeamLineups(fixture.FixtureId);
                
                // Filter home and away team lineups
                // make sure case of designation attribute returned is not an issue
                // Microsoft documeetation: Case-insensitive ordinal comparisons: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings          
                var homeTeamLineup = fixtureTeamLineups.FirstOrDefault(t => string.Equals(t.Designation, "home", StringComparison.OrdinalIgnoreCase));
                var awayTeamLineup = fixtureTeamLineups.FirstOrDefault(t => string.Equals(t.Designation, "away", StringComparison.OrdinalIgnoreCase));

                // New instance of the FixtureInfo on each iteration, initialse with the individual fixtures information
                var fixtureInfo = new FixtureInfo
                {
                    CompetitionId = competitionId,
                    FixtureId = fixture.FixtureId,
                    SrSportEventId = fixture.SrSportEventId,
                    RoundNumber = fixture.RoundNumber,
                    StartTime = fixture.StartTime,
                    Status = fixture.Status,
                    HomeScore = fixture.HomeScore,
                    AwayScore = fixture.AwayScore,
                };
                
                // check if awayTeamLineup returned from API as null before adding to List<FixtureInfo>
                if (homeTeamLineup != null)
                {
                    // if not null, fetch home team info from Api and add to List<FixtureInfo>
                    var homeTeam = await _rugbyDataApiService.GetTeamById(homeTeamLineup.TeamId);
                    fixtureInfo.HomeTeamId = homeTeamLineup.TeamId;
                    fixtureInfo.HomeTeamName = homeTeam?.TeamName;
                }

                // check if awayTeamLineup returned from API as null before adding to List<FixtureInfo>
                if (awayTeamLineup != null)
                {
                    // if not null, fetch away team info from Api and add to List<FixtureInfo>
                    var awayTeam = await _rugbyDataApiService.GetTeamById(awayTeamLineup.TeamId);
                    fixtureInfo.AwayTeamId = awayTeamLineup.TeamId;
                    fixtureInfo.AwayTeamName = awayTeam?.TeamName;
                }
                
                // Add each FixtureInfo Object to the fixturesInfo List
                fixturesInfo.Add(fixtureInfo);
            }

            // Add data fetched & manipulated from above and add to view model
            var ViewModel = new FixtureViewModel()
            {
                CompetitionName = competition.CompetitionName,
                CompetitionId = competitionId,
                SrCompetitionId = competition.SrCompetitionId,
                FixturesInfo = fixturesInfo,
            };

            // return view including relevant data
            return View(ViewModel);
        }
        
        // GET: Fixtures/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureById(id));  
        }

        // GET: fixtures/Create
        public async Task<IActionResult> Create(int competitionId)
        {
            Fixture fixture = new Fixture()
            {
                CompetitionId = competitionId
            };
            
            return View(fixture);
        }

        // POST: fixtures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // MP Note: binding attributes causes an issue in some instances, may need to remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixtureId, SrSportEventId, RoundNumber, StartTime, Status, HomeScore, AwayScore, CompetitionId")] Fixture fixture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _rugbyDataApiService.AddFixture(fixture);
                    return RedirectToAction("Index", new { competitionId = fixture.CompetitionId });  
                }
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(fixture);
            }
            catch (Exception ex)
            {
                // Log exception details
                _logger.LogError(ex, "Error creating Fixture");
                throw;
            }
        }
        
        // GET: fixtures/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureById(id));
        }

        // POST: fixtures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // MP Note: binding attributes causes an issue in some instances, may need to remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FixtureId, SrSportEventId, RoundNumber, StartTime, Status, HomeScore, AwayScore, CompetitionId")]  int id, Fixture fixture)
        {
            if (id != fixture.FixtureId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditFixtureById(id, fixture);
            return RedirectToAction("Details", new { id = fixture.FixtureId });
        }

        // GET: fixtures/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureById(id));
        }

        // POST: fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeleteFixtureById(id);
            return RedirectToAction("Index");
        }

        // Create Dropdown for linked relational model; Competitions [use in Create view]
        private async Task CompetitionDropdownList()
        {
            var competitions = await _rugbyDataApiService.GetAllCompetitions();

            ViewBag.competitions = new SelectList(competitions, "CompetitionId", "Competition_Name");
        }
    }
}
