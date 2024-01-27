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
    [Route("api/v1/teamLineups/")]
    [ApiController]
    public class TeamLineupController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public TeamLineupController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamLineup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamLineup>>> GetTeamLineups()
        {
            if (_context.TeamLineups == null)
            {
                return NotFound("No players Statistics store in the database");
            }
            return await _context.TeamLineups.ToListAsync();
        }

        // GET: api/TeamLineup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamLineup>> GetTeamLineup(int id)
        {
            if (_context.TeamLineups == null)
            {
                return NotFound("No Player Statistics Id provided");
            }
            var playerMatchStatistics = await _context.TeamLineups.FindAsync(id);

            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            return playerMatchStatistics;
        }

        // PUT: api/TeamLineup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamLineup(int id, TeamLineup playerMatchStatistics)
        {
            if (id != playerMatchStatistics.TeamLineupId)
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
                if (!TeamLineupExists(id))
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

        // POST: api/TeamLineup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamLineup>> PostTeamLineup(TeamLineup playerMatchStatistics)
        {
          if (_context.TeamLineups == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.PlayersMatchStatistics'  is null.");
          }
            _context.TeamLineups.Add(playerMatchStatistics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeamLineupExists(playerMatchStatistics.TeamLineupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeamLineup", new { id = playerMatchStatistics.TeamLineupId }, playerMatchStatistics);
        }

        // DELETE: api/TeamLineup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamLineup(int id)
        {
            if (_context.TeamLineups == null)
            {
                return NotFound();
            }
            var playerMatchStatistics = await _context.TeamLineups.FindAsync(id);
            if (playerMatchStatistics == null)
            {
                return NotFound();
            }

            _context.TeamLineups.Remove(playerMatchStatistics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamLineupExists(int id)
        {
            return (_context.TeamLineups?.Any(e => e.TeamLineupId == id)).GetValueOrDefault();
        }
    }
}
