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
    public class MatchDayTeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RugbyDataApiService _rugbyDataApiService;

        private readonly IHttpClientFactory _clientFactory;

        public MatchDayTeamController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: MatchDayTeams
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetMatchDayTeams());
        }

        // GET: MatchDayTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MatchDayTeam == null)
            {
                return NotFound(); //404
            }

            //SELECT * FROM matchDayTeams
            //WHERE Id = 5;
            var matchDayTeam = await _context.MatchDayTeam
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (matchDayTeam == null)
            {
                return NotFound();
            }

            return View(matchDayTeam);
        }

        // GET: MatchDayTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatchDayTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, MatchDayTeam_Name, Country")] MatchDayTeam matchDayTeam)
        {
            if (ModelState.IsValid)
            {

                //INSERT INTO CLUBS ("Id, SportRadar_Id, Competition_Name, MatchDayTeam_Name, Country")
                //VALUES (matchDayTeam.Id, matchDayTeam.SportRadar_Id, matchDayTeam.Competition_Name, matchDayTeam.MatchDayTeam_Name, matchDayTeam.Country);

                _context.Add(matchDayTeam);

                await _context.SaveChangesAsync();
                //COMMIT;
                return RedirectToAction(nameof(Index));
            }
            return View(matchDayTeam);
        }

        // GET: MatchDayTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MatchDayTeam == null)
            {
                return NotFound();
            }

            var matchDayTeam = await _context.MatchDayTeam.FindAsync(id);
            if (matchDayTeam == null)
            {
                return NotFound();
            }
            return View(matchDayTeam);
        }

        // POST: MatchDayTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, SportRadar_Id, Competition_Name, MatchDayTeam_Name, Country")] MatchDayTeam matchDayTeam)
        {
            if (id != matchDayTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchDayTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchDayTeamExists(matchDayTeam.Id))
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
            return View(matchDayTeam);
        }

        // GET: MatchDayTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MatchDayTeam == null)
            {
                return NotFound();
            }

            var matchDayTeam = await _context.MatchDayTeam
                .FirstOrDefaultAsync(c => c.Id == id);
            if (matchDayTeam == null)
            {
                return NotFound();
            }

            return View(matchDayTeam);
        }

        // POST: MatchDayTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MatchDayTeam == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MatchDayTeam' is null.");
            }
            var matchDayTeam = await _context.MatchDayTeam.FindAsync(id);
            if (matchDayTeam != null)
            {
                _context.MatchDayTeam.Remove(matchDayTeam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchDayTeamExists(int id)
        {
          return (_context.MatchDayTeam?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
