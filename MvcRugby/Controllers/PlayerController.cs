using Microsoft.AspNetCore.Mvc;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Services;


namespace MvcRugby.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public PlayerController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }     
        
        // GET: Players
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllPlayers());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerById(id));  
        }

        // GET: clubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId, SrPlayerId, FirstName, LastName, DateOfBirth, Nationality, TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddPlayer(player);
                return RedirectToAction("Index");  
            }
            return View(player);
        }
        
        // GET: players/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerById(id));
        }

        // POST: players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PlayerId, SrPlayerId, FirstName, LastName, DateOfBirth, Nationality, TeamId")] int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditPlayerById(id, player);
            return RedirectToAction("Details", new { id = player.PlayerId });
        }

        // GET: players/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerById(id));
        }

        // POST: players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeletePlayerById(id);
            return RedirectToAction("Index");
        }
    }
}
