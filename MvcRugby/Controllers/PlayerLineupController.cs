using Microsoft.AspNetCore.Mvc;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Services;


namespace MvcRugby.Controllers
{
    public class PlayerLineupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public PlayerLineupsController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: PlayerLineups
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllPlayerLineups());
        }

        // GET: PlayerLineups/Details/5
       public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerLineupById(id));  
        }

        // GET: playerLineupss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: playerLineups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerLineupId, SrPlayerId, JerseyNumber, PlayerId, TeamLineupId")] PlayerLineup playerLineups)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddPlayerLineup(playerLineups);
                return RedirectToAction("Index");  
            }
            return View(playerLineups);
        }
        
        // GET: playerLineups/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerLineupById(id));
        }

        // POST: playerLineups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PlayerLineupId, SrPlayerId, JerseyNumber, PlayerId, TeamLineupId")] int id, PlayerLineup playerLineups)
        {
            if (id != playerLineups.PlayerLineupId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditPlayerLineupById(id, playerLineups);
            return RedirectToAction("Details", new { id = playerLineups.PlayerLineupId });
        }

        // GET: playerLineups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerLineupById(id));
        }

        // POST: playerLineups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeletePlayerLineupById(id);
            return RedirectToAction("Index");
        }
    }
}
