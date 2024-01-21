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
    public class ComparisonController : Controller
    {
        private readonly ILogger<ComparisonController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public ComparisonController(ApplicationDbContext context, IHttpClientFactory clientFactory, ILogger<ComparisonController> logger)
        {
            _context = context;
            _clientFactory = clientFactory;
            _logger = logger;
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
        
        //Get: All fixtures in a given Competition, group by round
        public async Task<IActionResult> Rounds(int id)
        {
            // Get all fixtures matching Comp Id
            HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
            string requestUri = $"/api/v1/fixture/competition/{id}"; // return all fixtures by competition by id, passed in as parameter
            
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var compFixtures = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Fixture>>(content);

                _logger.LogInformation($"Competitions data received: {Newtonsoft.Json.JsonConvert.SerializeObject(content)}");
                
                if (compFixtures != null)
                {
                    var ViewModel = new RoundsViewModel()
                    {
                        // RoundsViewModel Attribute = Competition Model Attribute path
                        // Group By method: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby?view=net-8.0 : 
                        // 'GroupBy' returns sequence of IGrouping<TKey, TElement> where TKey is the key and TElement is the type of elements within each group. 
                        CompetitionName = null, 
                        CompetitionId = id,
                        Rounds = compFixtures
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
        public async Task<IActionResult> RoundFixtures()
        {
            
        }




    }
}