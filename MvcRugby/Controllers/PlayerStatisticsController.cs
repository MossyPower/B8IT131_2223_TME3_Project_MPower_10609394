using Microsoft.AspNetCore.Mvc;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.ViewModels;
using MvcRugby.Services;

namespace MvcRugby.Controllers
{
    public class PlayerStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public PlayerStatisticsController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }    
        
        public async Task<IActionResult> Index(int competitionId, int playerId, int fixtureId)
        {
            if(competitionId != 0 && playerId != 0 && fixtureId != 0)
            {
                var competition = await _rugbyDataApiService.GetCompetitionById(competitionId); 
                var player = await _rugbyDataApiService.GetPlayerById(playerId);           
                var fixture = await _rugbyDataApiService.GetFixtureById(fixtureId);          
                var playerStatistics = await _rugbyDataApiService.GetPlayerFixtureStatistics(playerId, fixtureId);                
            
                if (playerStatistics != null)
                {
                    var ViewModel = new PlayerStatisticsViewModel()
                    {
                        CompetitionId = competitionId,
                        CompetitionName = competition.CompetitionName,
                        FixtureId = fixtureId,
                        FixtureStartTime = fixture.StartTime,
                        PlayerId = playerId,
                        PlayerFirstName = player.FirstName,
                        PlayerLastName = player.LastName,
                        PlayerStatistics = playerStatistics,
                        Placeholder = null,
                    };
                    return View(ViewModel);
                }
                else
                {
                    var ViewModel = new PlayerStatisticsViewModel()
                    {
                        Placeholder = "There are no statistics currently recorded for this player or fixture",
                    };
                    return View(ViewModel);
                }
            }
            else
            {
                var ViewModel = new PlayerStatisticsViewModel()
                {
                    Placeholder = "There are no statistics currently recorded for this player or fixture",
                };
                return View(ViewModel);
            }
        }


        // GET: PlayerStatistics/Details/5
       public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerStatisticsById(id));  
        }

        // GET: playerStatisticss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: playerStatisticss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerStatisticsId, Tries, TryAssists, Conversions, PenaltyGoals, DropGoals, MetersRun, Carries, Passes, Offloads, CleanBreaks, LineoutsWon, LineoutsLost, Tackles, TacklesMissed, ScrumsWon, ScrumsLost, TotalScrums, TurnoversWon, PenaltiesConceded, YellowCards, RedCards, PlayerId, FixtureId")] PlayerStatistics playerStatistics)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddPlayerStatistics(playerStatistics);
                return RedirectToAction("Index");  
            }
            return View(playerStatistics);
        }
        
        // GET: playerStatisticss/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerStatisticsById(id));
        }

        // POST: playerStatisticss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PlayerStatisticsId, Tries, TryAssists, Conversions, PenaltyGoals, DropGoals, MetersRun, Carries, Passes, Offloads, CleanBreaks, LineoutsWon, LineoutsLost, Tackles, TacklesMissed, ScrumsWon, ScrumsLost, TotalScrums, TurnoversWon, PenaltiesConceded, YellowCards, RedCards, PlayerId, FixtureId")] int id, PlayerStatistics playerStatistics)
        {
            if (id != playerStatistics.PlayerStatisticsId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditPlayerStatisticsById(id, playerStatistics);
            return RedirectToAction("Details", new { id = playerStatistics.PlayerStatisticsId });
        }

        // GET: playerStatisticss/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerStatisticsById(id));
        }

        // POST: playerStatisticss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeletePlayerStatisticsById(id);
            return RedirectToAction("Index");
        }
    }
}
