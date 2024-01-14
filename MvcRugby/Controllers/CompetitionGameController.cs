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
    public class CompetitionGameController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RugbyDataApiService _rugbyDataApiService;

        private readonly IHttpClientFactory _clientFactory;

        public CompetitionGameController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: CompetitionGames
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetCompetitionGames());
        }

        // GET: CompetitionGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompetitionGame == null)
            {
                return NotFound(); //404
            }

            //SELECT * FROM competitionGames
            //WHERE Id = 5;
            var competitionGame = await _context.CompetitionGame
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (competitionGame == null)
            {
                return NotFound();
            }

            return View(competitionGame);
        }

        // GET: CompetitionGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetitionGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, CompetitionGame_Name, Country")] CompetitionGame competitionGame)
        {
            if (ModelState.IsValid)
            {

                //INSERT INTO CLUBS ("Id, SportRadar_Id, Competition_Name, CompetitionGame_Name, Country")
                //VALUES (competitionGame.Id, competitionGame.SportRadar_Id, competitionGame.Competition_Name, competitionGame.CompetitionGame_Name, competitionGame.Country);

                _context.Add(competitionGame);

                await _context.SaveChangesAsync();
                //COMMIT;
                return RedirectToAction(nameof(Index));
            }
            return View(competitionGame);
        }

        // GET: CompetitionGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompetitionGame == null)
            {
                return NotFound();
            }

            var competitionGame = await _context.CompetitionGame.FindAsync(id);
            if (competitionGame == null)
            {
                return NotFound();
            }
            return View(competitionGame);
        }

        // POST: CompetitionGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, SportRadar_Id, Competition_Name, CompetitionGame_Name, Country")] CompetitionGame competitionGame)
        {
            if (id != competitionGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competitionGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionGameExists(competitionGame.Id))
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
            return View(competitionGame);
        }

        // GET: CompetitionGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompetitionGame == null)
            {
                return NotFound();
            }

            var competitionGame = await _context.CompetitionGame
                .FirstOrDefaultAsync(c => c.Id == id);
            if (competitionGame == null)
            {
                return NotFound();
            }

            return View(competitionGame);
        }

        // POST: CompetitionGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CompetitionGame == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CompetitionGame' is null.");
            }
            var competitionGame = await _context.CompetitionGame.FindAsync(id);
            if (competitionGame != null)
            {
                _context.CompetitionGame.Remove(competitionGame);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionGameExists(int id)
        {
          return (_context.CompetitionGame?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
