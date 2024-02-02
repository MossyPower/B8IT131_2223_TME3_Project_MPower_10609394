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
    [Route("api/v1/team/")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public TeamController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeam()
        {
            if (_context.Teams == null)
            {
                return NotFound();
            }
            return await _context.Teams.ToListAsync();
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            if (_context.Teams == null)
            {
                return NotFound();
            }
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // GET: return all teams by team id
        [HttpGet("fixture/{id}")]
        public async Task<ActionResult<IEnumerable<Team>>> GetFixtureTeamLineups(int id)
        {
            if (_context.TeamLineups == null)
            {
                return NotFound("No fixture Id provided");
            }
            var teams = await _context.Teams
                .Where(t => t.TeamId == id)
                .ToListAsync();

            if (teams == null)
            {
                return NotFound();
            }

            return teams;
        }

        //GET: list of all the Teams for each round, using a list of teamIds
        [HttpGet("roundteams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetRoundTeams([FromQuery] List<int> roundTeamsIds)
        {
            if (roundTeamsIds == null || roundTeamsIds.Count == 0)
            {
                return BadRequest("No fixture IDs provided");
            }

            var teams = await _context.Teams
                .Where(p => roundTeamsIds.Contains(p.TeamId))  // return all Teams in the Db if the teamsId matches the list of teamsIds provided
                .ToListAsync(); // Add all the Teams found to a list

            if (teams == null || teams.Count == 0)
            {
                return NotFound("No team lineups found for the provided fixture IDs");
            }

            return teams;
        }

        // PUT: api/Team/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Team
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            if (_context.Teams == null)
            {
              return Problem("Entity set 'RugbyDataDbContext.Team' is null.");
            }
            _context.Teams.Add(team);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeamExists(team.TeamId) || TeamExistsBySrId(team.SrCompetitorId)) 
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeam", new { id = team.TeamId }, team);
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (_context.Teams == null)
            {
                return NotFound();
            }
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return (_context.Teams?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }
        private bool TeamExistsBySrId(string SrCompetitorId)
        {
            return (_context.Teams?.Any(e => e.SrCompetitorId == SrCompetitorId)).GetValueOrDefault();
        }
    }
}
