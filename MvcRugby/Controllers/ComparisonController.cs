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
        
        //Get: All Competitions
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
        
        //Get: All rounds in a given Competition
        public async Task<IActionResult> Rounds(int CompetitionId)
        {
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/competition/{CompetitionId}"; // return competition by id passed in as parameter
            
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var competition = await response.Content.ReadFromJsonAsync<Competition>();

                if (competition != null && competition.Fixtures != null)
                {
                    var ViewModel = new RoundsViewModel()
                    {
                        // RoundsViewModel Attribute = Competition Model Attribute path
                        // Group By method: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby?view=net-8.0 : 
                        // 'GroupBy' returns sequence of IGrouping<TKey, TElement> where TKey is the key and TElement is the type of elements within each group. 
                        CompetitionName = competition.Competition_Name, 
                        CompetitionId = competition.CompetitionId,
                        Rounds = competition.Fixtures
                        .GroupBy(item => item.Round_Number)
                        .Select(group => new RoundInfoViewModel //each item in the list is an instance of the RoundsViewModel (within the CompRoundsViewModel) 
                        {
                            RoundNumber = group.Key, // Group key is the round number
                            Status = group.First().Status
                            //StartDate = group.First()Start_Time,
                            //EndDate = group.First().sport_event?.start_time_confirmed ?? false
                        })
                        .ToList()
                    };
                    return View(ViewModel);
                }
                else
                {
                    return NotFound(); // Handle the case where Fixtures or competition is null
                }
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
        
        // Get: CreateFixture view
        // public async Task<IActionResult> CreateFixture(int CompetitionId)
        // {
        //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
        //     string requestUri = $"/api/v1/competition/{CompetitionId}"; // return competition by id passed in as parameter
            
        //     HttpResponseMessage response = await client.GetAsync(requestUri);
            
        //     var competition = await response.Content.ReadFromJsonAsync<Competition>();

        //     if (competition == null)
        //     {
        //         return NotFound();
        //     }

        //     var viewModel = new FixtureViewModel
        //     {
        //         CompetitionId = competition.Id,
        //         CompetitionName = competition.Competition_Name,
        //         // Set other properties as needed
        //     };

        //     return View(viewModel);
        // }
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