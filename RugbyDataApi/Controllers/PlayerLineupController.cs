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
    [Route("api/v1/playerLineups/")]
    [ApiController]
    public class PlayerLineupController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public PlayerLineupController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerLineup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerLineup>>> GetPlayerLineups()
        {
            if (_context.PlayerLineups == null)
            {
                return NotFound("No players Statistics store in the database");
            }
            return await _context.PlayerLineups.ToListAsync();
        }

        // GET: api/PlayerLineup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerLineup>> GetPlayerLineup(int id)
        {
            if (_context.PlayerLineups == null)
            {
                return NotFound("No Player Statistics Id provided");
            }
            var playerMatchStatistics = await _context.PlayerLineups.FindAsync(id);

            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return playerMatchStatistics;
        }

        // PUT: api/PlayerLineup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerLineup(int id, PlayerLineup playerMatchStatistics)
        {
            if (id != playerMatchStatistics.PlayerLineupId)
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
                if (!PlayerLineupExists(id))
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

        // POST: api/PlayerLineup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerLineup>> PostPlayerLineup(PlayerLineup playerMatchStatistics)
        {
          if (_context.PlayerLineups == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.PlayersMatchStatistics'  is null.");
          }
            _context.PlayerLineups.Add(playerMatchStatistics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerLineupExists(playerMatchStatistics.PlayerLineupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerLineup", new { id = playerMatchStatistics.PlayerLineupId }, playerMatchStatistics);
        }

        // DELETE: api/PlayerLineup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerLineup(int id)
        {
            if (_context.PlayerLineups == null)
            {
                return NotFound();
            }
            var playerMatchStatistics = await _context.PlayerLineups.FindAsync(id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            _context.PlayerLineups.Remove(playerMatchStatistics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerLineupExists(int id)
        {
            return (_context.PlayerLineups?.Any(e => e.PlayerLineupId == id)).GetValueOrDefault();
        }
    }
}
