using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcRugby.Models;

namespace MvcRugby.Controllers;

public class ComparisonController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ComparisonController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
