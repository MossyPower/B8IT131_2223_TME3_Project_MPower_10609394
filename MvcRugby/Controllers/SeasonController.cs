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

        // GET: Seasons - Using Interface & Service Layer
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _rugbyDataApiService.GetSeasons());
        // }

        // GET: Seasons
        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/season/";
            
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var season = await response.Content.ReadFromJsonAsync<List<Season>>();
                return View(season);
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

        // GET: Seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/season/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var season = await response.Content.ReadFromJsonAsync<Season>();
                return View(season);
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

        // GET: seasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: seasons/Create - Using Interface & Service Layer
        // public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, season_Name, Country")] Season season)
        // {
        //     await _rugbyDataApiService.CreateSeason(season);
            
        //     return RedirectToAction(nameof(Index));
        // }

        // POST: seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Season season)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = "/api/v1/season";

            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, season);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        
        // GET: seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/season/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var season = await response.Content.ReadFromJsonAsync<Season>();
                return View(season);
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

        // POST: seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Season season)
        {
            if (id != season.Id)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/season/{id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, season);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = season.Id });
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

        // GET: seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/season/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var season= await response.Content.ReadFromJsonAsync<Season>();
                return View(season);
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

        // POST: seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/season/{id}";

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

        private bool seasonExists(int id)
        {
          return (_context.Season?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
