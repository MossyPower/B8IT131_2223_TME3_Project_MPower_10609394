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
    [Route("api/v1/playerstatistics/")]
    [ApiController]
    public class PlayerStatisticsController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public PlayerStatisticsController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerStatistics>>> GetPlayersStatistics()
        {
            if (_context.PlayersStatistics == null)
            {
                return NotFound("No players Statistics store in the database");
            }
            return await _context.PlayersStatistics.ToListAsync();
        }

        // GET: api/PlayerStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerStatistics>> GetPlayerStatistics(int id)
        {
            if (_context.PlayersStatistics == null)
            {
                return NotFound("No Player Statistics Id provided");
            }
            var playerStatistics = await _context.PlayersStatistics.FindAsync(id);

            if (playerStatistics == null)
            {
                return NotFound();
            }

            return playerStatistics;
        }

        // PUT: api/PlayerStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerStatistics(int id, PlayerStatistics playerStatistics)
        {
            if (id != playerStatistics.PlayerStatisticsId)
            {
                return BadRequest();
            }

            _context.Entry(playerStatistics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerStatisticsExists(id))
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

        // POST: api/PlayerStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerStatistics>> PostPlayerStatistics(PlayerStatistics playerStatistics)
        {
          if (_context.PlayersStatistics == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.PlayersStatistics' is null.");
          }
            _context.PlayersStatistics.Add(playerStatistics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerStatisticsExists(playerStatistics.PlayerStatisticsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerStatistics", new { id = playerStatistics.PlayerStatisticsId }, playerStatistics);
        }

        // DELETE: api/PlayerStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerStatistics(int id)
        {
            if (_context.PlayersStatistics == null)
            {
                return NotFound();
            }
            var playerStatistics = await _context.PlayersStatistics.FindAsync(id);
            if (playerStatistics == null)
            {
                return NotFound();
            }

            _context.PlayersStatistics.Remove(playerStatistics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerStatisticsExists(int id)
        {
            return (_context.PlayersStatistics?.Any(e => e.PlayerStatisticsId == id)).GetValueOrDefault();
        }
    }
}
