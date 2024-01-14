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
    //[Authorize]
    public class SeasonController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RugbyDataApiService _rugbyDataApiService;

        private readonly IHttpClientFactory _clientFactory;

        public SeasonController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: Seasons
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetSeasons());
        }

        // GET: Seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Season == null)
            {
                return NotFound(); //404
            }

            //SELECT * FROM seasons
            //WHERE Id = 5;
            var season = await _context.Season
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // GET: seasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, season_Name, Country")] Season season)
        {
            if (ModelState.IsValid)
            {

                //INSERT INTO seasonS ("Id, SportRadar_Id, Competition_Name, season_Name, Country")
                //VALUES (season.Id, season.SportRadar_Id, season.Competition_Name, season.season_Name, season.Country);

                _context.Add(season);

                await _context.SaveChangesAsync();
                //COMMIT;
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }

        // GET: seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Season == null)
            {
                return NotFound();
            }

            var season = await _context.Season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }
            return View(season);
        }

        // POST: seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, SportRadar_Id, Competition_Name, season_Name, Country")] Season season)
        {
            if (id != season.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(season);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!seasonExists(season.Id))
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
            return View(season);
        }

        // GET: seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Season == null)
            {
                return NotFound();
            }

            var season = await _context.Season
                .FirstOrDefaultAsync(c => c.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Season == null)
            {
                return Problem("Entity set 'ApplicationDbContext.season' is null.");
            }
            var season = await _context.Season.FindAsync(id);
            if (season != null)
            {
                _context.Season.Remove(season);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool seasonExists(int id)
        {
          return (_context.Season?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
