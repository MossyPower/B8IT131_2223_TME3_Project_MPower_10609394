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
    [Route("api/v1/playermatchstatistics/")]
    [ApiController]
    public class PlayerFixtureStatisticsController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public PlayerFixtureStatisticsController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerFixtureStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerFixtureStatistics>>> GetPlayersMatchStatistics()
        {
          if (_context.PlayerFixtureStatistics == null)
          {
              return NotFound();
          }
            return await _context.PlayerFixtureStatistics.ToListAsync();
        }

        // GET: api/PlayerFixtureStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerFixtureStatistics>> GetPlayerFixtureStatistics(int id)
        {
          if (_context.PlayerFixtureStatistics == null)
          {
              return NotFound();
          }
            var playerMatchStatistics = await _context.PlayerFixtureStatistics.FindAsync(id);

            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return playerMatchStatistics;
        }

        // PUT: api/PlayerFixtureStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerFixtureStatistics(int id, PlayerFixtureStatistics playerMatchStatistics)
        {
            if (id != playerMatchStatistics.Id)
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
                if (!PlayerFixtureStatisticsExists(id))
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

        // POST: api/PlayerFixtureStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerFixtureStatistics>> PostPlayerFixtureStatistics(PlayerFixtureStatistics playerMatchStatistics)
        {
          if (_context.PlayerFixtureStatistics == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.PlayersMatchStatistics'  is null.");
          }
            _context.PlayerFixtureStatistics.Add(playerMatchStatistics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerFixtureStatisticsExists(playerMatchStatistics.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerFixtureStatistics", new { id = playerMatchStatistics.Id }, playerMatchStatistics);
        }

        // DELETE: api/PlayerFixtureStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerFixtureStatistics(int id)
        {
            if (_context.PlayerFixtureStatistics == null)
            {
                return NotFound();
            }
            var playerMatchStatistics = await _context.PlayerFixtureStatistics.FindAsync(id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            _context.PlayerFixtureStatistics.Remove(playerMatchStatistics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerFixtureStatisticsExists(int id)
        {
            return (_context.PlayerFixtureStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
