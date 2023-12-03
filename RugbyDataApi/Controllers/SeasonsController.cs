// Need to scaffold a new controller for each model

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Data;
using RugbyDataApi.Models;

namespace RugbyDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RugbyDataController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public RugbyDataController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/RugbyData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seasons>>> GetSeasons()
        {
            if (_context.Seasons == null)
            {
                return NotFound();
            }
            return await _context.Seasons.ToListAsync();
        }

        // GET: api/RugbyData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seasons>> GetSeason(string id)
        {
            if (_context.Seasons == null)
            {
                return NotFound();
            }
            var season = await _context.Seasons.FindAsync(id);

            if (season == null)
            {
                return NotFound();
            }

            return season;
        }

        // PUT: api/RugbyData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeason(string id, Seasons season)
        {
            if (id != season.id)
            {
                return BadRequest();
            }

            _context.Entry(season).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RugbyData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seasons>> PostSeason(Seasons season)
        {
            if (_context.Seasons == null)
            {
                return Problem("Entity set 'RugbyDataDbContext.Seasons' is null.");
            }
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();
            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateException)
            // {
            //     if (SeasonExists(season.id))
            //     {
            //         return Conflict();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            return CreatedAtAction("GetSeason", new { id = season.id }, season);
        }

        // DELETE: api/RugbyData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(string id)
        {
            if (_context.Seasons == null)
            {
                return NotFound();
            }
            var season = await _context.Seasons.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }

            _context.Seasons.Remove(season);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeasonExists(string id)
        {
            return (_context.Seasons?.Any(e => e.SeasonId == id)).GetValueOrDefault();
        }
    }
}
