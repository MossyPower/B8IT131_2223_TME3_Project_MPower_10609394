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
    public class TeamLineupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public TeamLineupsController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: TeamLineups
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllTeamLineups());
        }

        // GET: TeamLineups/Details/5
       public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetTeamLineupById(id));  
        }

        // GET: teamLineupss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: teamLineupss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamLineupId, Designation, FixtureId, TeamId")] TeamLineup teamLineups)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddTeamLineup(teamLineups);
                return RedirectToAction("Index");  
            }
            return View(teamLineups);
        }
        
        // GET: teamLineupss/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetTeamLineupById(id));
        }

        // POST: teamLineupss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("TeamLineupId, Designation, FixtureId, TeamId")] int id, TeamLineup teamLineups)
        {
            if (id != teamLineups.TeamLineupId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditTeamLineupById(id, teamLineups);
            return RedirectToAction("Details", new { id = teamLineups.TeamLineupId });
        }

        // GET: teamLineupss/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetTeamLineupById(id));
        }

        // POST: teamLineupss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeleteTeamLineupById(id);
            return RedirectToAction("Index");
        }
    }
}
