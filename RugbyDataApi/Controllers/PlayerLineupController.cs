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
    [Route("api/v1/playerlineup/")]
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
                return NotFound("No player lineups stored in the database");
            }
            return await _context.PlayerLineups.ToListAsync();
        }

        // GET: api/PlayerLineup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerLineup>> GetPlayerLineup(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid PlayerLineupId provided");
            }

            var playerLineup = await _context.PlayerLineups.FindAsync(id);

            if (playerLineup == null)
            {
                return NotFound("No PlayerLineups found for the provided PlayerLineupId");
            }

            return playerLineup;
        }

        // GET: all Player Lineups by Team Lineup Id
        [HttpGet("teamlineup/{id}")]
        public async Task<ActionResult<IEnumerable<PlayerLineup>>> GetAllPlayerLineupsById(int id)
        {
            if (_context.PlayerLineups == null)
            {
                return NotFound("No team lineup id provided");
            }
            var playerLineups = await _context.PlayerLineups
                .Where(p => p.TeamLineupId == id)
                .ToListAsync();


            if (playerLineups == null)
            {
                return NotFound();
            }

            return playerLineups;
        }
        
        [HttpGet("roundplayerlineups/{id}")]
        public async Task<ActionResult<IEnumerable<PlayerLineup>>> GetPlayerLineupByTeamLineupId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid TeamLineupId provided");
            }

            // Retrieve PlayerLineups with a matching TeamLineupId
            var playerLineups = await _context.PlayerLineups
                .Where(p => p.TeamLineupId == id)
                .ToListAsync();

            // Check if any PlayerLineups were found
            if (playerLineups == null)
            {
                return NotFound("No PlayerLineups found for the provided TeamLineupId");
            }

            return playerLineups;
        }

        //GET: list of all the PlayerLineups for each round, using a list of teamLineupIds
        [HttpGet("round")]
        public async Task<ActionResult<IEnumerable<PlayerLineup>>> GetTeamLineupsByFixtureIds([FromQuery] List<int> teamLineupIds)
        {
            if (teamLineupIds == null || teamLineupIds.Count == 0)
            {
                return BadRequest("No fixture IDs provided");
            }

            var playerLineups = await _context.PlayerLineups
                .Where(p => teamLineupIds.Contains(p.TeamLineupId))  // return all PlayerLineups in the Db if the teamLineupId matches the list of teamLineupIds
                .ToListAsync(); // Add all the PlayerLineups found to a list

            if (playerLineups == null || playerLineups.Count == 0)
            {
                return NotFound("No team lineups found for the provided fixture IDs");
            }

            return playerLineups;
        }

        // PUT: api/PlayerLineup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerLineup(int id, PlayerLineup playerLineup)
        {
            if (id != playerLineup.PlayerLineupId)
            {
                return BadRequest();
            }

            _context.Entry(playerLineup).State = EntityState.Modified;

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
        public async Task<ActionResult<PlayerLineup>> PostPlayerLineup(PlayerLineup playerLineup)
        {
            if (_context.PlayerLineups == null)
            {
                return Problem("Entity set 'RugbyDataDbContext.PlayerLineups' is null.");
            }
            _context.PlayerLineups.Add(playerLineup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerLineupExists(playerLineup.PlayerLineupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerLineup", new { id = playerLineup.PlayerLineupId }, playerLineup);
        }

        // DELETE: api/PlayerLineup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerLineup(int id)
        {
            if (_context.PlayerLineups == null)
            {
                return NotFound();
            }
            var playerLineup = await _context.PlayerLineups.FindAsync(id);
            if (playerLineup == null)
            {
                return NotFound();
            }

            _context.PlayerLineups.Remove(playerLineup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerLineupExists(int id)
        {
            return (_context.PlayerLineups?.Any(e => e.PlayerLineupId == id)).GetValueOrDefault();
        }
    }
}
