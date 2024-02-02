using Microsoft.AspNetCore.Mvc;
using System.Net;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Services;

namespace MvcRugby.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;
        public CompetitionController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: Competitions
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllCompetitions());
        }
        
        // GET: Competition Fixtures
        public async Task<IActionResult> Fixtures(int id)
        {
            return View(await _rugbyDataApiService.GetCompetitionFixtures(id));
        }

        // GET: Competitions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetCompetitionById(id));  
        }

        // GET: competitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: competitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetitionId, SrCompetitionId, CompetitionName, StartDate, EndDate, Year")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddCompetition(competition);
                return RedirectToAction("Index");  
            }
            return View(competition);
        }
        
        // GET: competitions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetCompetitionById(id));
        }

        // POST: competitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CompetitionId, SrCompetitionId, CompetitionName, StartDate, EndDate, Year")] int id, Competition competition)
        {
            if (id != competition.CompetitionId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditCompetitionById(id, competition);
            return RedirectToAction("Details", new { id = competition.CompetitionId });
        }

        // GET: competitions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetCompetitionById(id));
        }

        // POST: competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeleteCompetitionById(id);
            return RedirectToAction("Index");
        }
    }
}
