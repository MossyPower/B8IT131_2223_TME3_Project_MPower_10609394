using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Mappings;
using MvcRugby.ViewModels;
using MvcRugby.Services;

namespace MvcRugby.Controllers
{
    //[Authorize]
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public TeamController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory, ILogger<TeamController> logger)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
            _logger = logger;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllTeams());
        }

        // GET: Team/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetTeamById(id));  
        }

        // Get: Team/Create View
        public async Task<IActionResult> Create()
        {
            try
            {
                _logger.LogInformation("Create GET action called.");
                
                // Populate the competitions dropdown
                await CompetitionDropdownList();
                
                // Create a new Team instance
                Team team = new Team();

                return View(team);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Create GET action: {ex.Message}");
                throw; // Rethrow the exception for now to see it in the console
            }
        }

        // Post (Create / Add) Team - Using Interface & Service Layer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId, SrCompetitorId, TeamName, Country")] Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Model State is valid.");

                    await _rugbyDataApiService.AddTeam(team);
                    
                    return RedirectToAction("Index");
                }
                // Handle invalid model state
                _logger.LogInformation("Model State is not valid.");
                return View(team);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error in Create POST action: {ex.Message}");
                var innerException = ex.InnerException;
                if (innerException != null)
                {
                    _logger.LogError($"Inner Exception: {innerException.Message}");
                }

                throw;
            }
        }

        // GET: teams/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetTeamById(id)); 
        }
        
        // POST: teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("TeamId, SrCompetitorId, TeamName, Country")] int id, Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }
            try
            {
                if(ModelState.IsValid)
                {
                    _logger.LogInformation("Model State is valid.");
                    
                    await _rugbyDataApiService.EditTeamById(id, team);
                    return RedirectToAction("Details", new { id = team.TeamId });
                }
                // Handle invalid model state
                _logger.LogInformation("Model State is not valid.");
                return View(team);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error in Create POST action: {ex.Message}");
                var innerException = ex.InnerException;
                if (innerException != null)
                {
                    _logger.LogError($"Inner Exception: {innerException.Message}");
                }
                throw;
            }
        }

        // GET: teams/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetTeamById(id));
        }

        // POST: teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeleteTeamById(id);
            return RedirectToAction("Index");
        }

        // Create Dropdown for linked relational model; Competition
        private async Task CompetitionDropdownList()
        {
            var competitions = await _rugbyDataApiService.GetAllCompetitions();

            ViewBag.competitions = new SelectList(competitions, "CompetitionId", "Competition_Name");
        }
    }
}