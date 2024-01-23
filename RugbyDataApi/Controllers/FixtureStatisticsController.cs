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
    [Route("api/v1/fixtureStatistics/")]
    [ApiController]
    public class FixtureStatisticsController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public FixtureStatisticsController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/FixtureStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixtureStatistics>>> GetFixturesStatistics()
        {
            if (_context.FixturesStatistics == null)
            {
                return NotFound("No fixtures Statistics store in the database");
            }
            return await _context.FixturesStatistics.ToListAsync();
        }

        // GET: api/FixtureStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FixtureStatistics>> GetFixtureStatistics(int id)
        {
            if (_context.FixturesStatistics == null)
            {
                return NotFound("No Fixture Statistics Id provided");
            }
            var playerMatchStatistics = await _context.FixturesStatistics.FindAsync(id);

            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return playerMatchStatistics;
        }

        // PUT: api/FixtureStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixtureStatistics(int id, FixtureStatistics playerMatchStatistics)
        {
            if (id != playerMatchStatistics.FixtureStatisticsId)
            {
                return BadRequest();
            }

            _context.Entry(playerMatchStatistics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixtureStatisticsExists(id))
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

        // POST: api/FixtureStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FixtureStatistics>> PostFixtureStatistics(FixtureStatistics playerMatchStatistics)
        {
          if (_context.FixturesStatistics == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.PlayersMatchStatistics'  is null.");
          }
            _context.FixturesStatistics.Add(playerMatchStatistics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FixtureStatisticsExists(playerMatchStatistics.FixtureStatisticsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFixtureStatistics", new { id = playerMatchStatistics.FixtureStatisticsId }, playerMatchStatistics);
        }

        // DELETE: api/FixtureStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixtureStatistics(int id)
        {
            if (_context.FixturesStatistics == null)
            {
                return NotFound();
            }
            var playerMatchStatistics = await _context.FixturesStatistics.FindAsync(id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            _context.FixturesStatistics.Remove(playerMatchStatistics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FixtureStatisticsExists(int id)
        {
            return (_context.FixturesStatistics?.Any(e => e.FixtureStatisticsId == id)).GetValueOrDefault();
        }
    }
}
