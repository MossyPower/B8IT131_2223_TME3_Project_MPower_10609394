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
    public class CompetitionRoundController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RugbyDataApiService _rugbyDataApiService;

        private readonly IHttpClientFactory _clientFactory;

        public CompetitionRoundController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: CompetitionRounds
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetCompetitionRounds());
        }

        // GET: CompetitionRounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompetitionRound == null)
            {
                return NotFound(); //404
            }

            //SELECT * FROM competitionRounds
            //WHERE Id = 5;
            var competitionRound = await _context.CompetitionRound
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (competitionRound == null)
            {
                return NotFound();
            }

            return View(competitionRound);
        }

        // GET: CompetitionRounds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetitionRounds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, CompetitionRound_Name, Country")] CompetitionRound competitionRound)
        {
            if (ModelState.IsValid)
            {

                //INSERT INTO CLUBS ("Id, SportRadar_Id, Competition_Name, CompetitionRound_Name, Country")
                //VALUES (competitionRound.Id, competitionRound.SportRadar_Id, competitionRound.Competition_Name, competitionRound.CompetitionRound_Name, competitionRound.Country);

                _context.Add(competitionRound);

                await _context.SaveChangesAsync();
                //COMMIT;
                return RedirectToAction(nameof(Index));
            }
            return View(competitionRound);
        }

        // GET: CompetitionRounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompetitionRound == null)
            {
                return NotFound();
            }

            var competitionRound = await _context.CompetitionRound.FindAsync(id);
            if (competitionRound == null)
            {
                return NotFound();
            }
            return View(competitionRound);
        }

        // POST: CompetitionRounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, SportRadar_Id, Competition_Name, CompetitionRound_Name, Country")] CompetitionRound competitionRound)
        {
            if (id != competitionRound.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competitionRound);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionRoundExists(competitionRound.Id))
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
            return View(competitionRound);
        }

        // GET: CompetitionRounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompetitionRound == null)
            {
                return NotFound();
            }

            var competitionRound = await _context.CompetitionRound
                .FirstOrDefaultAsync(c => c.Id == id);
            if (competitionRound == null)
            {
                return NotFound();
            }

            return View(competitionRound);
        }

        // POST: CompetitionRounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CompetitionRound == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CompetitionRound' is null.");
            }
            var competitionRound = await _context.CompetitionRound.FindAsync(id);
            if (competitionRound != null)
            {
                _context.CompetitionRound.Remove(competitionRound);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionRoundExists(int id)
        {
          return (_context.CompetitionRound?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
