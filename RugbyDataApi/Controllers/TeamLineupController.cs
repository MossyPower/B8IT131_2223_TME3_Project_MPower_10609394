using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Data;
using RugbyDataApi.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace RugbyDataApi.Controllers
{
    [Route("api/v1/teamlineup/")]
    [ApiController]
    public class TeamLineupController : ControllerBase
    {      
        
        private readonly ILogger<TeamLineupController> _logger;
        private readonly RugbyDataDbContext _context;

        public TeamLineupController(ILogger<TeamLineupController> logger, RugbyDataDbContext context)
        {
            _logger = logger;
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
       
        // GET: all team lineups by fixture id
        [HttpGet("fixture/{id}")]
        public async Task<ActionResult<IEnumerable<TeamLineup>>> GetFixtureTeamLineups(int id)
        {
            if (_context.TeamLineups == null)
            {
                return NotFound("No fixture Id provided");
            }
            var teamLineups = await _context.TeamLineups
                .Where(t => t.FixtureId == id)
                .ToListAsync();

            if (teamLineups == null)
            {
                return NotFound();
            }

            return teamLineups;
        }
        
        //GET: list of all the TeamLineups for each round, using a list of fixture Ids
        [HttpGet("fixtures")]
        public async Task<ActionResult<IEnumerable<TeamLineup>>> GetTeamLineupsByFixtureIds([FromQuery] List<int> fixtureids)
        {
            if (fixtureids == null || fixtureids.Count == 0)
            {
                return BadRequest("No fixture IDs provided");
            }

            var teamLineups = await _context.TeamLineups
                .Where(t => fixtureids.Contains(t.FixtureId))  // return all TeamLineups in the Db if the fixtureId matches the list of fixtureIds
                .ToListAsync(); // Add all the TeamLineups found to a list

            if (teamLineups == null || teamLineups.Count == 0)
            {
                return NotFound("No team lineups found for the provided fixture IDs");
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
            _logger.LogInformation("This is an informational log message.");
            _logger.LogWarning("This is a warning log message.");
            _logger.LogError("This is an error log message.");
            
            _logger.LogInformation("The PostTeamLineup method in the RugbyDataApi has been reached successfully.");

            if (_context.TeamLineups == null)
            {
                _logger.LogError("Entity set 'RugbyDataDbContext.TeamLineups' is null.");
                return Problem("Entity set 'RugbyDataDbContext.TeamLineups' is null.");
            }
            
            _logger.LogInformation($"Received TeamLineup payload: {Newtonsoft.Json.JsonConvert.SerializeObject(teamLineups)}");
            
            if (!ModelState.IsValid)
            {
                _logger.LogError($"ModelState errors: {string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))}");
                _logger.LogError($"ModelState errors: {ModelState.Values.SelectMany(v => v.Errors)}");
                return BadRequest(ModelState);
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
