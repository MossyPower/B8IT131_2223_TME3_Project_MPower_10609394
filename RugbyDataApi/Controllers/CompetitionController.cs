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
    [Route("api/v1/competition/")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public CompetitionController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/Competition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
        {
          if (_context.Competitions == null)
          {
              return NotFound();
          }
            return await _context.Competitions.ToListAsync();
        }

        // GET: api/Competition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(string id)
        {
          if (_context.Competitions == null)
          {
              return NotFound();
          }
            var competition = await _context.Competitions.FindAsync(id);

            if (competition == null)
            {
                return NotFound();
            }

            return competition;
        }

        // PUT: api/Competition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(string id, Competition competition)
        {
            if (id != competition.Id)
            {
                return BadRequest();
            }

            _context.Entry(competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(id))
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

        // POST: api/Competition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Competition>> PostCompetition(Competition competition)
        {
          if (_context.Competitions == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.Competitions'  is null.");
          }
            _context.Competitions.Add(competition);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompetitionExists(competition.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompetition", new { id = competition.Id }, competition);
        }

        // DELETE: api/Competition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(string id)
        {
            if (_context.Competitions == null)
            {
                return NotFound();
            }
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionExists(string id)
        {
            return (_context.Competitions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
