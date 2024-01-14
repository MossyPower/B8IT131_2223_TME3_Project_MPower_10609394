using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using MvcRugby.Data;
using MvcRugby.Mappings;
using MvcRugby.Models;

//namespace MvcRugby.Controllers;

// public class SeasonsController : Controller
// {
//     private readonly ILogger<SeasonsController> _logger;

//     public SeasonsController(ILogger<SeasonsController> logger)
//     {
//         _logger = logger;
//     }

//     public IActionResult Index()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }

namespace MvcRugby.Controllers;

public class SeasonsController : Controller
{
    private readonly ILogger<SeasonsController> _logger;

    public SeasonsController(ApplicationDbContext context, IHttpClientFactory clientFactory)
    {
        _context = context;
        _clientFactory = clientFactory;
    }    

    private readonly ApplicationDbContext _context;

    private readonly IHttpClientFactory _clientFactory;  
    
    public IActionResult Index()
    {
        return View();
    }

    // //GET: Seasons | Season Lineups | Players       
    // public async Task<IActionResult> Index()
    // {
    //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
    //     string requestUri = $"/api/v1/Seasons";
        
    //     HttpResponseMessage response = await client.GetAsync(requestUri);
        
    //     if (response.IsSuccessStatusCode)
    //     {
    //         var seasons = await response.Content.ReadFromJsonAsync<Seasons>();
    //         return View(seasons);
    //     }
    //     else
    //     {
    //         // return View(new SeasonsViewModel());
    //         return NotFound();
    //     }
    // }

    // // GET: Seasons / Details / 5
    // public async Task<IActionResult> Details(int? id)
    // {
    //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
    //     string requestUri = $"/api/v1/Seasons/{id}";

    //     HttpResponseMessage response = await client.GetAsync(requestUri);
        
    //     if (response.IsSuccessStatusCode)
    //     {
    //         var season = await response.Content.ReadFromJsonAsync<Seasons>();
    //         return View(season);
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

    // // GET: Seasons / Create
    // public IActionResult Create()
    // {
    //     return View();
    // }

    // // POST: Seasons/Create
    // // To protect from overposting attacks, enable the specific properties you want to bind to.
    // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Create(Seasons season)
    // {
    //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
    //     string requestUri = "/api/v1/seasons";

    //     HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, season);

    //     if (response.IsSuccessStatusCode)
    //     {
    //         return RedirectToAction("Index");
    //     }
    //     else
    //     {
    //         return StatusCode((int)response.StatusCode);
    //     }
    // }

    // // GET: Products / Edit / 5
    // public async Task<IActionResult> Edit(int? id)
    // {
    //     if (id == null)
    //     {
    //         return BadRequest();
    //     }

    //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
    //     string requestUri = $"/api/v1/seasons/{id}";

    //     HttpResponseMessage response = await client.GetAsync(requestUri);

    //     if (response.IsSuccessStatusCode)
    //     {
    //         var season = await response.Content.ReadFromJsonAsync<Seasons>();
    //         return View(season);
    //     }
    //     else if (response.StatusCode == HttpStatusCode.NotFound)
    //     {
    //         return NotFound();
    //     }
    //     else
    //     {
    //         return StatusCode((int)response.StatusCode);
    //     }
    // }

    // // POST: Products / Edit / 5
    // // To protect from overposting attacks, enable the specific properties you want to bind to.
    // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Edit(int id, Seasons season)
    // {
    //     // if (id != season.Id)
    //     // {
    //     //     return BadRequest();
    //     // }
        
    //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
    //     string requestUri = $"/api/v1/products/{id}";

    //     HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, season);
        
    //     if (response.IsSuccessStatusCode)
    //     {
    //         return RedirectToAction("Details", new { id = season.Id });
    //     }
    //     else if (response.StatusCode == HttpStatusCode.NotFound)
    //     {
    //         return NotFound();
    //     }
    //     else
    //     {
    //         return StatusCode((int)response.StatusCode);
    //     }
    // }

    // // GET: Products / Delete / 5
    // public async Task<IActionResult> Delete(int? id)
    // {
    //     if (id == null)
    //     {
    //         return BadRequest();
    //     }
        
    //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
    //     string requestUri = $"/api/v1/seasons/{id}";

    //     HttpResponseMessage response = await client.GetAsync(requestUri);
        
    //     if (response.IsSuccessStatusCode)
    //     {
    //         var season = await response.Content.ReadFromJsonAsync<Seasons>();
    //         return View(season);
    //     }
    //     else if (response.StatusCode == HttpStatusCode.NotFound)
    //     {
    //         return NotFound();
    //     }
    //     else
    //     {
    //         return StatusCode((int)response.StatusCode);
    //     }
    // }

    // // POST: Seasons / Delete / 5
    // [HttpPost, ActionName("Delete")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> DeleteConfirmed(int id)
    // {
    //     HttpClient client = _clientFactory.CreateClient(name: "RugbyDataApi");
    //     string requestUri = $"/api/v1/seasons/{id}";

    //     HttpResponseMessage response = await client.DeleteAsync(requestUri);

    //     if (response.IsSuccessStatusCode)
    //     {
    //         return RedirectToAction("Index");
    //     }
    //     else if (response.StatusCode == HttpStatusCode.NotFound)
    //     {
    //         return NotFound();
    //     }
    //     else
    //     {
    //         return StatusCode((int)response.StatusCode);
    //     }
    // }

    // private bool ProductExists(int id)
    // {
    //   return (_context.seasons?.Any(e => e.Id == id)).GetValueOrDefault();
    // }
}
