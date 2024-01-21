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

        // public async Task<IActionResult> Index()
        // {
        //     return View();
        // }
        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixture/";
            
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var allFixtures = await response.Content.ReadFromJsonAsync<List<Fixture>>();
                return View(allFixtures);
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
        // GET: Fixtures by CompetitionId
        // public async Task<IActionResult> Index(int competitionId)
        // {           
        //     // Get a list of all fixtures by Competition Id (passed in as param)
        //     HttpClient client1 = _clientFactory.CreateClient(name: "RugbyDataApi");
        //     string requestUri1 = $"/api/v1/fixture/Competition/{competitionId}";
        //     HttpResponseMessage response1 = await client1.GetAsync(requestUri1);

        //     // Get the correct Competition by Id
        //     HttpClient client2 = _clientFactory.CreateClient(name: "RugbyDataApi");
        //     string requestUri2 = $"/api/v1/Competition/{competitionId}";
        //     HttpResponseMessage response2 = await client2.GetAsync(requestUri2);


        //     if (response1.IsSuccessStatusCode) //&& response2.IsSuccessStatusCode
        //     {
        //         var fixtures = await response1.Content.ReadFromJsonAsync<List<Fixture>>();
                
        //         // Fetch the competition object from the database
        //         var competition = await response1.Content.ReadFromJsonAsync<Competition>();
                
        //         if(fixtures != null && competition != null)
        //         {
        //             foreach (var fixture in fixtures)
        //             {
        //                 fixture.CompetitionId = competition.CompetitionId;
        //                 fixture.Competition = competition;
        //             }
        //         }             
        //         return View(fixtures);
        //     }
        //     else if (response1.StatusCode == HttpStatusCode.NotFound) //|| response2.StatusCode == HttpStatusCode.NotFound
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         // Handle other error cases
        //         return StatusCode((int)response1.StatusCode);
        //     }
        // }

        // GET: Fixtures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixture/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var fixture = await response.Content.ReadFromJsonAsync<Fixture>();
                return View(fixture);
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

        // Return Create Fixture View
        // GET: fixtures/Create
        public async Task<IActionResult> Create()
        {           
            //Get all competitions & Associated Id for the dropdownlist
            // HttpClient client1 = _clientFactory.CreateClient(name: "RugbyDataApi");
            // string requestUri1 = $"/api/v1/competition/";
            // HttpResponseMessage response1 = await client1.GetAsync(requestUri1);
            
            // var competitions = await response1.Content.ReadFromJsonAsync<List<Competition>>();
            
            // ViewBag.CompetitionList = new SelectList(competitions, "CompetitionId", "CompetitionName");

            // Get Competition by Id
            // HttpClient client2 = _clientFactory.CreateClient(name: "RugbyDataApi");
            // string requestUri2 = $"/api/v1/competition/{id}";
            // HttpResponseMessage response2 = await client2.GetAsync(requestUri2);
            
            // var competition = await response1.Content.ReadFromJsonAsync<Competition>();
            
            // var ViewModel = new CompetitionFixturesViewModel.Competition()
            // {
            //     CompetitionId = competition.CompetitionId,
            //     Competition_Name = competition.Competition_Name,
            // };

            // return View(ViewModel);
            return View();
        }

        // public async Task<IActionResult> Create(int id)
        // {
        //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
        //     string requestUri = $"/api/v1/competition/{id}";

        //     HttpResponseMessage response = await client.GetAsync(requestUri);
        //     if (response.IsSuccessStatusCode)
        //     {
        //         var fixture = await response.Content.ReadFromJsonAsync<Competition>();
        //         return View(fixture);
        //     }
        //     else if (response.StatusCode == HttpStatusCode.NotFound)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         // Handle other error cases
        //         return StatusCode((int)response.StatusCode);
        //     }
        // }

        // POST: fixtures/Create - Using Interface & Service Layer
        // public async Task<IActionResult> Create([Bind("Id, SportRadar_Id, Competition_Name, fixture_Name, Country")] Fixture fixture)
        // {
        //     await _rugbyDataApiService.CreateFixture(fixture);
            
        //     return RedirectToAction(nameof(Index));
        // }

        // POST: fixtures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fixture fixture)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = "/api/v1/fixture";

            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, fixture);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        
        // GET: fixtures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixture/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var fixture = await response.Content.ReadFromJsonAsync<Fixture>();
                return View(fixture);
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

        // POST: fixtures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fixture fixture)
        {
            if (id != fixture.FixtureId)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixture/{id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, fixture);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = fixture.FixtureId });
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

        // GET: fixtures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixture/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var fixture= await response.Content.ReadFromJsonAsync<Fixture>();
                return View(fixture);
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

        // POST: fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixture/{id}";

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

        private bool fixtureExists(int id)
        {
          return (_context.Fixtures?.Any(e => e.FixtureId == id)).GetValueOrDefault();
        }
    }
}
