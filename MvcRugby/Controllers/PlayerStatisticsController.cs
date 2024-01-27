using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Mappings;
using MvcRugby.ViewModels;
using MvcRugby.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net;

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

        // GET: PlayerStatistics
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllPlayersStatistics());
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
