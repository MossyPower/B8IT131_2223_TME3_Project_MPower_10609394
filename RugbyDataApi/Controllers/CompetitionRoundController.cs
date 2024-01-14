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
    [Route("api/v1/competitionround/")]
    [ApiController]
    public class CompetitionRoundController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public CompetitionRoundController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/CompetitionRound
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitionRound>>> GetCompetitionRounds()
        {
          if (_context.CompetitionRound == null)
          {
              return NotFound();
          }
            return await _context.CompetitionRound.ToListAsync();
        }

        // GET: api/CompetitionRound/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionRound>> GetCompetitionRound(int id)
        {
          if (_context.CompetitionRound == null)
          {
              return NotFound();
          }
            var competitionRound = await _context.CompetitionRound.FindAsync(id);

            if (competitionRound == null)
            {
                return NotFound();
            }

            return competitionRound;
        }

        // PUT: api/CompetitionRound/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitionRound(int id, CompetitionRound competitionRound)
        {
            if (id != competitionRound.Id)
            {
                return BadRequest();
            }

            _context.Entry(competitionRound).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionRoundExists(id))
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

        // POST: api/CompetitionRound
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompetitionRound>> PostCompetitionRound(CompetitionRound competitionRound)
        {
          if (_context.CompetitionRound == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.CompetitionRounds'  is null.");
          }
            _context.CompetitionRound.Add(competitionRound);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompetitionRoundExists(competitionRound.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompetitionRound", new { id = competitionRound.Id }, competitionRound);
        }

        // DELETE: api/CompetitionRound/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitionRound(int id)
        {
            if (_context.CompetitionRound == null)
            {
                return NotFound();
            }
            var competitionRound = await _context.CompetitionRound.FindAsync(id);
            if (competitionRound == null)
            {
                return NotFound();
            }

            _context.CompetitionRound.Remove(competitionRound);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionRoundExists(int id)
        {
            return (_context.CompetitionRound?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
