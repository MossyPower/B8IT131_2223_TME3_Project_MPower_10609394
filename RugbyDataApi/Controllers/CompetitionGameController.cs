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
    [Route("api/v1/competitiongame/")]
    [ApiController]
    public class CompetitionGameController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public CompetitionGameController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/CompetitionGame
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitionGame>>> GetCompetitionGames()
        {
          if (_context.CompetitionGame == null)
          {
              return NotFound();
          }
            return await _context.CompetitionGame.ToListAsync();
        }

        // GET: api/CompetitionGame/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionGame>> GetCompetitionGame(int id)
        {
          if (_context.CompetitionGame == null)
          {
              return NotFound();
          }
            var competitionGame = await _context.CompetitionGame.FindAsync(id);

            if (competitionGame == null)
            {
                return NotFound();
            }

            return competitionGame;
        }

        // PUT: api/CompetitionGame/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitionGame(int id, CompetitionGame competitionGame)
        {
            if (id != competitionGame.Id)
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
                if (!CompetitionGameExists(id))
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

        // POST: api/CompetitionGame
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompetitionGame>> PostCompetitionGame(CompetitionGame competitionGame)
        {
          if (_context.CompetitionGame == null)
          {
              return Problem("Entity set 'RugbyDataDbContext.CompetitionGames'  is null.");
          }
            _context.CompetitionGame.Add(competitionGame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompetitionGameExists(competitionGame.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompetitionGame", new { id = competitionGame.Id }, competitionGame);
        }

        // DELETE: api/CompetitionGame/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitionGame(int id)
        {
            if (_context.CompetitionGame == null)
            {
                return NotFound();
            }
            var competitionGame = await _context.CompetitionGame.FindAsync(id);
            if (competitionGame == null)
            {
                return NotFound();
            }

            _context.CompetitionGame.Remove(competitionGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionGameExists(int id)
        {
            return (_context.CompetitionGame?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
