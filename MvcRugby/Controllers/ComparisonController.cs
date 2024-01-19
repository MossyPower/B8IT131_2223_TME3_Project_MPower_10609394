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
    public class ComparisonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public ComparisonController(ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }
        
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
        
        public async Task<IActionResult> Rounds(int? id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{id}"; // return competition by id passed in as parameter
            
            HttpResponseMessage response = await client.GetAsync(requestUri);
            
            var competition = await response.Content.ReadFromJsonAsync<Competition>();
            return View(competition);

            // Group By method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby?view=net-8.0
            // 'GroupBy' returns sequence of IGrouping<TKey, TElement> where TKey is the key and TElement is the type of elements within each group.

            // if (response.IsSuccessStatusCode)
            // {
            //     var competition = await response.Content.ReadFromJsonAsync<Competition>();

            //     if (competition != null && competition.Fixtures != null)
            //     {
            //         var compRounds = competition.Fixtures
            //             .Where(fixture => fixture.Round_Number != null) // Ensure Round_Number is not null
            //             .GroupBy(fixture => fixture.Round_Number)
            //             .Select(group => new TestRoundViewModel
            //             {
            //                 RoundNumber = group.Key ?? -1, // Use -1 as a default value if Key is null
            //                 Fixtures = group.ToList()
            //             })
            //             .ToList();

            //         return View(compRounds);
            //     }
            //     else
            //     {
            //         return NotFound(); // Handle the case where Fixtures or competition is null
            //     }
            // }
            // else if (response.StatusCode == HttpStatusCode.NotFound)
            // {
            //     return NotFound();
            // }
            // else
            // {
            //     return StatusCode((int)response.StatusCode);
            // }
        }
        
        // FixtureViewModel
        public async Task<IActionResult> CreateFixture(int competitionId)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{competitionId}"; // return competition by id passed in as parameter
            
            HttpResponseMessage response = await client.GetAsync(requestUri);
            
            var competition = await response.Content.ReadFromJsonAsync<Competition>();

            if (competition == null)
            {
                return NotFound();
            }

            var viewModel = new FixtureViewModel
            {
                CompetitionId = competition.Id,
                CompetitionName = competition.Competition_Name,
                // Set other properties as needed
            };

            return View(viewModel);
        }
        // [HttpPost]
        // public async Task<IActionResult> CreateFixture(FixtureViewModel viewModel)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         // Create a new Fixture using data from the ViewModel
        //         var newFixture = new Fixture
        //         {
        //             CompetitionId = viewModel.CompetitionId,
        //             // Set other properties from the form

        //             // Assuming you have a DbSet<Fixture> in your context
        //         };

        //         _context.Fixtures.Add(newFixture);
        //         await _context.SaveChangesAsync();

        //         return RedirectToAction("Details", "Competition", new { id = viewModel.CompetitionId });
        //     }

        //     // If model validation fails, return to the form with validation errors
        //     return View(viewModel);
        // }
    }
}