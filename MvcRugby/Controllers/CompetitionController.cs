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

        // GET: Competitions - Using Interface & Service Layer
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _rugbyDataApiService.GetCompetitions());
        // }

        // GET: Competitions
        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/";
            
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var competition = await response.Content.ReadFromJsonAsync<List<Competition>>();
                return View(competition);
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

        // GET: Competitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var competition = await response.Content.ReadFromJsonAsync<Competition>();
                return View(competition);
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

        // GET: competitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: competitions/Create - Using Interface & Service Layer
        // public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, competition_Name, Country")] Competition competition)
        // {
        //     await _rugbyDataApiService.CreateCompetition(competition);
            
        //     return RedirectToAction(nameof(Index));
        // }

        // POST: competitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Competition competition)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = "/api/v1/competition";

            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, competition);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        
        // GET: competitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var competition = await response.Content.ReadFromJsonAsync<Competition>();
                return View(competition);
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

        // POST: competitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Competition competition)
        {
            if (id != competition.CompetitionId)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, competition);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = competition.CompetitionId });
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

        // GET: competitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var competition= await response.Content.ReadFromJsonAsync<Competition>();
                return View(competition);
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

        // POST: competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{id}";

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
    }
}
