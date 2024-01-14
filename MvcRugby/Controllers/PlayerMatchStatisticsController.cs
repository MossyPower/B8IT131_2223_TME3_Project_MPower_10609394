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

namespace MvcRugby.Controllers
{
    [Authorize]
    public class PlayerMatchStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RugbyDataApiService _rugbyDataApiService;

        private readonly IHttpClientFactory _clientFactory;

        public PlayerMatchStatisticsController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: PlayerMatchStatisticss
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetPlayerMatchStatistics());
        }

        // GET: PlayerMatchStatisticss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlayerMatchStatistics == null)
            {
                return NotFound(); //404
            }

            //SELECT * FROM playerMatchStatisticss
            //WHERE Id = 5;
            var playerMatchStatistics = await _context.PlayerMatchStatistics
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return View(playerMatchStatistics);
        }

        // GET: PlayerMatchStatisticss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerMatchStatisticss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, PlayerMatchStatistics_Name, Country")] PlayerMatchStatistics playerMatchStatistics)
        {
            if (ModelState.IsValid)
            {

                //INSERT INTO CLUBS ("Id, SportRadar_Id, Competition_Name, PlayerMatchStatistics_Name, Country")
                //VALUES (playerMatchStatistics.Id, playerMatchStatistics.SportRadar_Id, playerMatchStatistics.Competition_Name, playerMatchStatistics.PlayerMatchStatistics_Name, playerMatchStatistics.Country);

                _context.Add(playerMatchStatistics);

                await _context.SaveChangesAsync();
                //COMMIT;
                return RedirectToAction(nameof(Index));
            }
            return View(playerMatchStatistics);
        }

        // GET: PlayerMatchStatisticss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlayerMatchStatistics == null)
            {
                return NotFound();
            }

            var playerMatchStatistics = await _context.PlayerMatchStatistics.FindAsync(id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }
            return View(playerMatchStatistics);
        }

        // POST: PlayerMatchStatisticss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, SportRadar_Id, Competition_Name, PlayerMatchStatistics_Name, Country")] PlayerMatchStatistics playerMatchStatistics)
        {
            if (id != playerMatchStatistics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerMatchStatistics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerMatchStatisticsExists(playerMatchStatistics.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playerMatchStatistics);
        }

        // GET: PlayerMatchStatisticss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlayerMatchStatistics == null)
            {
                return NotFound();
            }

            var playerMatchStatistics = await _context.PlayerMatchStatistics
                .FirstOrDefaultAsync(c => c.Id == id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return View(playerMatchStatistics);
        }

        // POST: PlayerMatchStatisticss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlayerMatchStatistics == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PlayerMatchStatistics' is null.");
            }
            var playerMatchStatistics = await _context.PlayerMatchStatistics.FindAsync(id);
            if (playerMatchStatistics != null)
            {
                _context.PlayerMatchStatistics.Remove(playerMatchStatistics);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerMatchStatisticsExists(int id)
        {
          return (_context.PlayerMatchStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
