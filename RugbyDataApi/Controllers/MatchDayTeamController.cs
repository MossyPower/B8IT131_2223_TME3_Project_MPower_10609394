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
    [Route("api/v1/matchdayteam/")]
    [ApiController]
    public class MatchDayTeamController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public MatchDayTeamController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/MatchDayTeam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDayTeam>>> GetMatchDayTeams()
        {
          if (_context.MatchDayTeam == null)
          {
              return NotFound();
          }
            return await _context.MatchDayTeam.ToListAsync();
        }

        // GET: api/MatchDayTeam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDayTeam>> GetMatchDayTeam(int id)
        {
          if (_context.MatchDayTeam == null)
          {
              return NotFound();
          }
            var matchDayTeam = await _context.MatchDayTeam.FindAsync(id);

            if (matchDayTeam == null)
            {
                return NotFound();
            }

            return matchDayTeam;
        }

        // PUT: api/MatchDayTeam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchDayTeam(int id, MatchDayTeam matchDayTeam)
        {
            if (id != matchDayTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(matchDayTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchDayTeamExists(id))
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

        // POST: api/MatchDayTeam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MatchDayTeam>> PostMatchDayTeam(MatchDayTeam matchDayTeam)
        {
          if (_context.MatchDayTeam == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.MatchDayTeams'  is null.");
          }
            _context.MatchDayTeam.Add(matchDayTeam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MatchDayTeamExists(matchDayTeam.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMatchDayTeam", new { id = matchDayTeam.Id }, matchDayTeam);
        }

        // DELETE: api/MatchDayTeam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchDayTeam(int id)
        {
            if (_context.MatchDayTeam == null)
            {
                return NotFound();
            }
            var matchDayTeam = await _context.MatchDayTeam.FindAsync(id);
            if (matchDayTeam == null)
            {
                return NotFound();
            }

            _context.MatchDayTeam.Remove(matchDayTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchDayTeamExists(int id)
        {
            return (_context.MatchDayTeam?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
