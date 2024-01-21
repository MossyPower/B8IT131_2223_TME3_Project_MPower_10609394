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
    [Route("api/v1/fixture/")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public FixtureController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/Fixture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fixture>>> GetFixtures()
        {
            if (_context.Fixtures == null)
            {
              return NotFound();
            }
            return await _context.Fixtures.ToListAsync();
        }

        // GET: api/Fixtures by Competition Id
        [HttpGet("Competition/{id}")]
        public async Task<ActionResult<IEnumerable<Fixture>>> GetFixturesByCompetitionId(int id)
        {
            if (_context.Fixtures == null)
            {
                return NotFound();
            }
            var fixtures = await _context.Fixtures
                .Where(f => f.CompetitionId == id)
                .ToListAsync();

            if (fixtures == null)
            {
                return NotFound();
            }

            return fixtures;
        }

        // GET: api/Fixture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fixture>> GetFixture(int id)
        {
            if (_context.Fixtures == null)
            {
              return NotFound();
            }
            var competitionGame = await _context.Fixtures.FindAsync(id);

            if (competitionGame == null)
            {
                return NotFound();
            }

            return competitionGame;
        }

        // PUT: api/Fixture/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixture(int id, Fixture competitionGame)
        {
            if (id != competitionGame.FixtureId)
            {
                return BadRequest();
            }

            _context.Entry(competitionGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixtureExists(id))
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

        // POST: api/Fixture
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fixture>> PostFixture(Fixture competitionGame)
        {
            if (_context.Fixtures == null)
            {
              return Problem("Entity set 'RugbyDataDbContext.Fixtures'  is null.");
            }
            _context.Fixtures.Add(competitionGame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FixtureExists(competitionGame.FixtureId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFixture", new { id = competitionGame.FixtureId }, competitionGame);
        }

        // DELETE: api/Fixture/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixture(int id)
        {
            if (_context.Fixtures == null)
            {
                return NotFound();
            }
            var competitionGame = await _context.Fixtures.FindAsync(id);
            if (competitionGame == null)
            {
                return NotFound();
            }

            _context.Fixtures.Remove(competitionGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FixtureExists(int id)
        {
            return (_context.Fixtures?.Any(e => e.FixtureId == id)).GetValueOrDefault();
        }
    }
}
