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
    public class FixtureStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RugbyDataApiService _rugbyDataApiService;

        private readonly IHttpClientFactory _clientFactory;

        public FixtureStatisticsController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }

        // GET: FixtureStatistics - Using Interface & Service Layer
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _rugbyDataApiService.GetFixtureStatisticss());
        // }

        // GET: FixtureStatisticss
        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixtureStatistics/";
            
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var fixtureStatistics = await response.Content.ReadFromJsonAsync<List<FixtureStatistics>>();
                return View(fixtureStatistics);
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

        // GET: FixtureStatisticss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixtureStatistics/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var fixtureStatistics = await response.Content.ReadFromJsonAsync<FixtureStatistics>();
                return View(fixtureStatistics);
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

        // GET: fixtureStatisticss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: fixtureStatisticss/Create - Using Interface & Service Layer
        // public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, fixtureStatistics_Name, Country")] FixtureStatistics fixtureStatistics)
        // {
        //     await _rugbyDataApiService.CreateFixtureStatistics(fixtureStatistics);
            
        //     return RedirectToAction(nameof(Index));
        // }

        // POST: fixtureStatisticss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FixtureStatistics fixtureStatistics)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = "/api/v1/fixtureStatistics";

            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, fixtureStatistics);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        
        // GET: fixtureStatisticss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixtureStatistics/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var fixtureStatistics = await response.Content.ReadFromJsonAsync<FixtureStatistics>();
                return View(fixtureStatistics);
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

        // POST: fixtureStatisticss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FixtureStatistics fixtureStatistics)
        {
            if (id != fixtureStatistics.Id)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixtureStatistics/{id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, fixtureStatistics);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = fixtureStatistics.Id });
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

        // GET: fixtureStatisticss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixtureStatistics/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var fixtureStatistics= await response.Content.ReadFromJsonAsync<FixtureStatistics>();
                return View(fixtureStatistics);
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

        // POST: fixtureStatisticss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixtureStatistics/{id}";

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

        private bool fixtureStatisticsExists(int id)
        {
          return (_context.FixtureStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
