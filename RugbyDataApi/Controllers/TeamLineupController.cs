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
    [Route("api/v1/teamlineups/")]
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
            var teamLineups = await _context.TeamLineups.FindAsync(id);

            if (teamLineups == null)
            {
                return NotFound();
            }

            return teamLineups;
        }

        // PUT: api/TeamLineup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamLineup(int id, TeamLineup teamLineups)
        {
            if (id != teamLineups.TeamLineupId)
            {
                return BadRequest();
            }

            _context.Entry(teamLineups).State = EntityState.Modified;

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
        public async Task<ActionResult<TeamLineup>> PostTeamLineup(TeamLineup teamLineups)
        {
          if (_context.TeamLineups == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.TeamLineups' is null.");
          }
            _context.TeamLineups.Add(teamLineups);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeamLineupExists(teamLineups.TeamLineupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeamLineup", new { id = teamLineups.TeamLineupId }, teamLineups);
        }

        // DELETE: api/TeamLineup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamLineup(int id)
        {
            if (_context.TeamLineups == null)
            {
                return NotFound();
            }
            var teamLineups = await _context.TeamLineups.FindAsync(id);
            if (teamLineups == null)
            {
                return NotFound();
            }

            _context.TeamLineups.Remove(teamLineups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamLineupExists(int id)
        {
            return (_context.TeamLineups?.Any(e => e.TeamLineupId == id)).GetValueOrDefault();
        }
    }
}
