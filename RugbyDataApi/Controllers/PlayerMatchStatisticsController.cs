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
          if (_context.PlayerMatchStatistics == null)
          {
              return NotFound();
          }
            return await _context.PlayerMatchStatistics.ToListAsync();
        }

        // GET: api/PlayerMatchStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerMatchStatistics>> GetPlayerMatchStatistics(int id)
        {
          if (_context.PlayerMatchStatistics == null)
          {
              return NotFound();
          }
            var playerMatchStatistics = await _context.PlayerMatchStatistics.FindAsync(id);

            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return playerMatchStatistics;
        }

        // PUT: api/PlayerMatchStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerMatchStatistics(int id, PlayerMatchStatistics playerMatchStatistics)
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
          if (_context.PlayerMatchStatistics == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.PlayersMatchStatistics'  is null.");
          }
            _context.PlayerMatchStatistics.Add(playerMatchStatistics);
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
        public async Task<IActionResult> DeletePlayerMatchStatistics(int id)
        {
            if (_context.PlayerMatchStatistics == null)
            {
                return NotFound();
            }
            var playerMatchStatistics = await _context.PlayerMatchStatistics.FindAsync(id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            _context.PlayerMatchStatistics.Remove(playerMatchStatistics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerMatchStatisticsExists(int id)
        {
            return (_context.PlayerMatchStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
