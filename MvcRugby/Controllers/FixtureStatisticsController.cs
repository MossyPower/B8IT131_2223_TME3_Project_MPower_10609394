using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace MvcRugby.Controllers
{
    public class FixtureStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public FixtureStatisticsController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: FixtureStatistics
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllFixturesStatistics());
        }

        // GET: FixtureStatistics/Details/5
       public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureStatisticsById(id));  
        }

        // GET: fixtureStatisticss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: fixtureStatisticss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixtureStatisticsId, SportRadar_Id, Tries, Try_Assists, Conversions, Penalty_Goals, Drop_Goals, Meters_Run, Carries, Passes, Offloads, Clean_Breaks, Lineouts_Won, Lineouts_Lost, Tackles, Tackles_Missed, Scrums_Won, Scrums_Lost, Total_Scrums, Turnovers_Won, Penalties_Conceded, Yellow_Cards, Red_Cards, PlayerId, FixtureId")] FixtureStatistics fixtureStatistics)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddFixtureStatistics(fixtureStatistics);
                return RedirectToAction("Index");  
            }
            return View(fixtureStatistics);
        }
        
        // GET: fixtureStatisticss/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureStatisticsById(id));
        }

        // POST: fixtureStatisticss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FixtureStatisticsId, SportRadar_Id, Tries, Try_Assists, Conversions, Penalty_Goals, Drop_Goals, Meters_Run, Carries, Passes, Offloads, Clean_Breaks, Lineouts_Won, Lineouts_Lost, Tackles, Tackles_Missed, Scrums_Won, Scrums_Lost, Total_Scrums, Turnovers_Won, Penalties_Conceded, Yellow_Cards, Red_Cards, PlayerId, FixtureId")] int id, FixtureStatistics fixtureStatistics)
        {
            if (id != fixtureStatistics.FixtureStatisticsId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditFixtureStatisticsById(id, fixtureStatistics);
            return RedirectToAction("Details", new { id = fixtureStatistics.FixtureStatisticsId });
        }

        // GET: fixtureStatisticss/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureStatisticsById(id));
        }

        // POST: fixtureStatisticss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeleteFixtureStatisticsById(id);
            return RedirectToAction("Index");
        }
    }
}
