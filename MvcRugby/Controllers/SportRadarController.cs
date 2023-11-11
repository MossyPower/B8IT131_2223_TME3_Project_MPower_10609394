using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcRugby.Models;
using MvcRugby.Services;
using Microsoft.AspNetCore.Authorization;

namespace MvcRugby.Controllers
{
    // [Authorize]
    public class SportRadarController : Controller
    {       
        //Create an instance of the SportRadarApiService class
        private readonly SportRadarApiService _sportRadarApiService;
        
        public SportRadarController(SportRadarApiService sportRadarApiService)
        {
            _sportRadarApiService = sportRadarApiService;
        }
        
        //Create new method for calling GetCompetitions method
        public async Task<IActionResult> Index()
        {
            var competitions = await _sportRadarApiService.GetCompetitions();
            if (competitions != null)
            {
                return View(competitions);
            }
            else
            {
                return NotFound();
            }
        }
        
        // URI: http://localhost:5254/SportRadar/Season
        public async Task<IActionResult> Season()
        {
            var seasons = await _sportRadarApiService.GetSeasons();
            if (seasons != null)
            {
                return View(seasons);
            }
            else
            {
                return NotFound();
            }
        }
        
        // URI: http://localhost:5254/SportRadar/GetSeasonLineups/sr%3Aseason%3A107205
        public async Task<IActionResult> SeasonLineups(string? id)
        {
            var seasonLineup = await _sportRadarApiService.GetSeasonLineups(id);
            if (seasonLineup != null)
            {
                return View(seasonLineup);
            }
            else
            {
                return NotFound();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}