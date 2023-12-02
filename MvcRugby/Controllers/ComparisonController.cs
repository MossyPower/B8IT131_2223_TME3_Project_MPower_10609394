using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using MvcRugby.Data;
using MvcRugby.Models;

namespace MvcRugby.Controllers
{
    public class ComparisonController : Controller
    {
        // private readonly ApplicationDbContext _context;

        // private readonly IHttpClientFactory _clientFactory;

        // public ComparisonController(ApplicationDbContext context, IHttpClientFactory clientFactory)
        // {
        //     _context = context;
        //     _clientFactory = clientFactory;
        // }

        // GET: Index / Start-page
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Competitions
        public async Task<IActionResult> Competitions()
        {
            return View();
        }
        
        // GET: Competition Rounds
        public async Task<IActionResult> CompRounds()
        {
            return View();
        }
        
        // GET: Round Lineup Comparison
        public async Task<IActionResult> RoundLineupComparison()
        {
            return View();
        }    
    }
}
