using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcRugby.Models;
using MvcRugby.Services;
using Microsoft.AspNetCore.Authorization;

namespace MvcRugby.Controllers
{
    // [Authorize]
    public class SeasonController : Controller
    {       
        //Create an instance of the SportRadarApiService class
        private readonly SportRadarApiService _sportRadarApiService;
        
        public SeasonController(SportRadarApiService sportRadarApiService)
        {
            _sportRadarApiService = sportRadarApiService;
        }
        
        //Create new method for calling GetCompetitions method
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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}