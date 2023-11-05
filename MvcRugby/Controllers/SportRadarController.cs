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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}