// This controller fetchs data from Sport Radar third-party API and stores in locally only. 
// Includes an automated background service to complete this.
// Background service restricts number of calls per second / month to comply with third-party call limits.
// This controller has no interaction with the MvcRugby App 

// Start background service / fect & store methods here
// Assumed one required for each end point in the Sports Radar Api, i.e.: 
// Seasons
// SeasonLineup
// Players ==> this should be changed to match results
//    ^^^^ Save each players statistics to a seperate mode in the local database

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using RugbyDataApi.Services;
using RugbyDataApi.Models;
using RugbyDataApi.Data;

namespace MvcRugby.Controllers
{
    // [Authorize]
    public class SportRadarController : Controller
    {       
        //Create an instance of the SportRadarApiService class
    
        private readonly RugbyDataDbContext _rugbyDataDbContext;
        private readonly SportRadarApiService _sportRadarApiService;
    
        public SportRadarController(RugbyDataDbContext rugbyDataDbContext, SportRadarApiService sportRadarApiService)
        {
            _rugbyDataDbContext = rugbyDataDbContext;
            _sportRadarApiService = sportRadarApiService;
        }
    
        // Get Seasons from Sports Radar Api
        [HttpGet]
        public async Task<IActionResult> SyncSeasons()
        {
            var seasonsFromApi = await _sportRadarApiService.GetCompetitions();

            // Save to the database
            // MP Resources:
            //      https://learn.microsoft.com/en-us/ef/core/change-tracking/miscellaneous#addrange-updaterange-attachrange-and-removerange
            //      
            _rugbyDataDbContext.seasons.AddRange(seasonsFromApi);
            await _rugbyDataDbContext.SaveChangesAsync();

            return Ok("Data synced successfully.");
        }
    }
}