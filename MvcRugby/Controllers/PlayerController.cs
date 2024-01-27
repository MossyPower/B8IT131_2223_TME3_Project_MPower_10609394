using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.Mappings;
using MvcRugby.ViewModels;
using MvcRugby.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace MvcRugby.Controllers
{
    //[Authorize]
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public PlayerController(ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }     
        
        // GET: Players
        public async Task<IActionResult> Index()
        {
            return View(await _rugbyDataApiService.GetAllPlayers());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerById(id));  
        }

        // GET: clubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId, SportRadar_Id, First_Name, Last_Name, Nationality, Position, Jersey_Number, Age, Weight, ClubId")] Player player)
        {
            if (ModelState.IsValid)
            {
                await _rugbyDataApiService.AddPlayer(player);
                return RedirectToAction("Index");  
            }
            return View(player);
        }
        
        // GET: players/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerById(id));
        }

        // POST: players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PlayerId, SportRadar_Id, First_Name, Last_Name, Nationality, Position, Jersey_Number, Age, Weight, ClubId")] int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditPlayerById(id, player);
            return RedirectToAction("Details", new { id = player.PlayerId });
        }

        // GET: players/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetPlayerById(id));
        }

        // POST: players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeletePlayerById(id);
            return RedirectToAction("Index");
        }
    }
}
