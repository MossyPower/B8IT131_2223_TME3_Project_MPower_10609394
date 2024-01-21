using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Services;

namespace MvcRugby.Controllers
{
    //[Authorize]
    public class ClubController : Controller
    {
        private readonly ILogger<ClubController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public ClubController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory, ILogger<ClubController> logger)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
            _logger = logger;
        }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllClubs());
        }

        // GET: Club/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetClubById(id));  
        }

        // Get: Club/Create View
        public async Task<IActionResult> Create()
        {
            try
            {
                _logger.LogInformation("Create GET action called.");
                
                // Populate the competitions dropdown
                await PopulateCompetitionsDropDownList();
            
                // Create a new Club instance
                Club club = new Club();

                return View(club);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Create GET action: {ex.Message}");
                throw; // Rethrow the exception for now to see it in the console
            }
        }

        // Post (Create / Add) Club - Using Interface & Service Layer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubId, SportRadar_Competitor_Id, Club_Name, CompetitionId")] Club club)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Model State is valid.");

                    await _rugbyDataApiService.AddClub(club);
                    
                    return RedirectToAction("Index");
                }
                // Handle invalid model state
                _logger.LogInformation("Model State is not valid.");
                return View(club);
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

        // GET: clubs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return View(await _rugbyDataApiService.GetClubById(id)); 
        }
        
        // POST: clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ClubId, SportRadar_Competitor_Id, Club_Name, CompetitionId")] int id, Club club)
        {
            if (id != club.ClubId)
            {
                return BadRequest();
            }
            try
            {
                if(ModelState.IsValid)
                {
                    _logger.LogInformation("Model State is valid.");
                    
                    await _rugbyDataApiService.EditClubById(id, club);
                    return RedirectToAction("Edit", new { id = club.ClubId });
                }
                // Handle invalid model state
                _logger.LogInformation("Model State is not valid.");
                return View(club);
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

        // POST: clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, Club club)
        // {
        //     if (id != club.ClubId)
        //     {
        //         return BadRequest();
        //     }

        //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
        //     string requestUri = $"/api/v1/club/{id}";

        //     HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, club);

        //     if (response.IsSuccessStatusCode)
        //     {
        //         return RedirectToAction("Details", new { id = club.ClubId });
        //     }
        //     else if (response.StatusCode == HttpStatusCode.NotFound)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         return StatusCode((int)response.StatusCode);
        //     }
        // }

        // GET: clubs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return View(await _rugbyDataApiService.GetClubById(id));
        }

        // POST: clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeleteClubById(id);
            return RedirectToAction("Index");
        }

        // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data?view=aspnetcore-8.0
        private async Task PopulateCompetitionsDropDownList(object selectedCompetition = null)
        {
            try
            {
                _logger.LogInformation("PopulateCompetitionsDropDownList method called.");

                using (HttpClient client = _clientFactory.CreateClient("RugbyDataApi"))
                {
                    string requestUri = "/api/v1/competition/";
                    HttpResponseMessage response = await client.GetAsync(requestUri);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var competitions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Competition>>(content);

                        _logger.LogInformation($"Competitions data received: {Newtonsoft.Json.JsonConvert.SerializeObject(competitions)}");

                        if (competitions != null)
                        {
                            ViewBag.CompetitionId = new SelectList(competitions, "CompetitionId", "Competition_Name", (selectedCompetition as Club)?.CompetitionId);
                        }
                        else
                        {
                            // Handle the case where no competitions were retrieved
                            ViewBag.Competitions = new SelectList(new List<Competition>(), "CompetitionId", "Competition_Name");
                        }
                    }
                    else
                    {
                        // Handle the case where the API request was not successful
                        _logger.LogError($"Error fetching competitions. StatusCode: {response.StatusCode}");
                        ViewBag.Competitions = new SelectList(new List<Competition>(), "CompetitionId", "Competition_Name");
                    }
                }
            }
            catch (Exception ex)
            {
                // https://www.youtube.com/watch?v=ZXynHdk35fU&ab_channel=CodeS @time: 12:55
                // Error logging - Delete method
                // string errMessage = ex.Message;
                // TempData["ErrorMessage"] = errMessage;
                // ModelState.AddModelError("", errMessage);
                // return View(Unit);
                
                _logger.LogError($"An error occurred while populating competitions: {ex.Message}");
                ViewBag.Competitions = new SelectList(new List<Competition>(), "CompetitionId", "Competition_Name");
            }
        }
    }
}