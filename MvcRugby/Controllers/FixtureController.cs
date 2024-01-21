using Microsoft.AspNetCore.Mvc;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Services;
using System.Net;

namespace MvcRugby.Controllers
{
    public class FixtureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public FixtureController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: Fixtures
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllFixtures());
        }

        // GET: Fixtures/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureById(id));  
        }

        // GET: fixtures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: fixtures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixtureId, SportRadar_Id, Round_Number, Fixture_Date, Start_Time, Status, Home_Team, Away_Team, Home_Score, Away_Score, CompetitionId")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddFixture(fixture);
                return RedirectToAction("Index");  
            }
            return View(fixture);
        }
        
        // GET: fixtures/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetFixtureById(id));
        }

        // POST: fixtures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FixtureId, SportRadar_Id, Round_Number, Fixture_Date, Start_Time, Status, Home_Team, Away_Team, Home_Score, Away_Score, CompetitionId")]  int id, Fixture fixture)
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
    }
}
