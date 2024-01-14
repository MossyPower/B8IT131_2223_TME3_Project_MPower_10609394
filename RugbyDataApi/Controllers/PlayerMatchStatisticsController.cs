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
    public class PlayerMatchStatisticsController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public PlayerMatchStatisticsController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerMatchStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerMatchStatistics>>> GetPlayersMatchStatistics()
        {
          if (_context.PlayersMatchStatistics == null)
          {
              return NotFound();
          }
            return await _context.PlayersMatchStatistics.ToListAsync();
        }

        // GET: api/PlayerMatchStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerMatchStatistics>> GetPlayerMatchStatistics(string id)
        {
          if (_context.PlayersMatchStatistics == null)
          {
              return NotFound();
          }
            var playerMatchStatistics = await _context.PlayersMatchStatistics.FindAsync(id);

            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return playerMatchStatistics;
        }

        // PUT: api/PlayerMatchStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerMatchStatistics(string id, PlayerMatchStatistics playerMatchStatistics)
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
                if (!PlayerMatchStatisticsExists(id))
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

        // POST: api/PlayerMatchStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerMatchStatistics>> PostPlayerMatchStatistics(PlayerMatchStatistics playerMatchStatistics)
        {
          if (_context.PlayersMatchStatistics == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.PlayersMatchStatistics'  is null.");
          }
            _context.PlayersMatchStatistics.Add(playerMatchStatistics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerMatchStatisticsExists(playerMatchStatistics.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerMatchStatistics", new { id = playerMatchStatistics.Id }, playerMatchStatistics);
        }

        // DELETE: api/PlayerMatchStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerMatchStatistics(string id)
        {
            if (_context.PlayersMatchStatistics == null)
            {
                return NotFound();
            }
            var playerMatchStatistics = await _context.PlayersMatchStatistics.FindAsync(id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            _context.PlayersMatchStatistics.Remove(playerMatchStatistics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerMatchStatisticsExists(string id)
        {
            return (_context.PlayersMatchStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
