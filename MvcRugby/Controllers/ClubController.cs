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
using System.Net;

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

        // GET: Clubs - Using Interface & Service Layer
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _rugbyDataApiService.GetClubs());
        // }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/club/";
            
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var club = await response.Content.ReadFromJsonAsync<List<Club>>();
                return View(club);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle other error cases
                return StatusCode((int)response.StatusCode);
            }
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/club/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var club = await response.Content.ReadFromJsonAsync<Club>();
                return View(club);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle other error cases
                return StatusCode((int)response.StatusCode);
            }
        }

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

        // public async Task<IActionResult> Create()
        // {
        //     try
        //     {
        //         _logger.LogInformation("Create GET action called.");
        //         PopulateCompetitionsDropDownList();
        //         return View(new Club());
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError($"Error in Create GET action: {ex.Message}");
        //         throw; // Rethrow the exception for now to see it in the console
        //     }
        // }
        
        //https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data?view=aspnetcore-8.0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubId, SportRadar_Competitor_Id, Club_Name, CompetitionId")] Club club)
        {
            try
            {
                _logger.LogInformation("Create POST action called.");

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Model State is valid.");
                    
                    HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
                    string requestUri = "/api/v1/club";

                    HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, club);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error in Create POST action: {response.StatusCode}");
                        return StatusCode((int)response.StatusCode);
                    }
                }
                // Log validation errors
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        _logger.LogError($"Validation error for {key}: {error.ErrorMessage}");
                    }
                }
                _logger.LogInformation("Model State is invalid.");

                //PopulateCompetitionsDropDownList(club.CompetitionId);
                // If ModelState is not valid, return to the view with validation errors
                return View(club);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error in Create POST action: {ex.Message}");

                // Log additional information if needed
                var innerException = ex.InnerException;
                if (innerException != null)
                {
                    _logger.LogError($"Inner Exception: {innerException.Message}");
                }

                throw;
            }
        }    

        // GET: clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/club/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var club = await response.Content.ReadFromJsonAsync<Club>();
                return View(club);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        // POST: clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Club club)
        {
            if (id != club.ClubId)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/club/{id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, club);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = club.ClubId });
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        // GET: clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/club/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var club= await response.Content.ReadFromJsonAsync<Club>();
                return View(club);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        // POST: clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/club/{id}";

            HttpResponseMessage response = await client.DeleteAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
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