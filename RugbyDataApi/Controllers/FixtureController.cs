using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Data;
using RugbyDataApi.Models;
using RugbyDataApi.DTOs;

namespace RugbyDataApi.Controllers
{
    [Route("api/v1/fixture/")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly ILogger<FixtureController> _logger;
        private readonly RugbyDataDbContext _context;

        public FixtureController(ILogger<FixtureController> logger, RugbyDataDbContext context)
        {
            _logger = logger;
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
        [HttpGet("competition/{id}")]
        public async Task<ActionResult<IEnumerable<Fixture>>> GetCompetitionFixtures(int id)
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

        // GET: api/Fixtures by Competition Id & round number
        [HttpGet("competition/{id}/round/{number}")]
        public async Task<ActionResult<IEnumerable<Fixture>>> GetRoundFixtures(int id, int number)
        {
            if (_context.Fixtures == null)
            {
                return NotFound();
            }
            var fixtures = await _context.Fixtures
                .Where(f => f.CompetitionId == id && f.RoundNumber == number)
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

        //GET: Fixture by Id, including all related data
        [HttpGet("withRelatedData/{id}")]
        public async Task<ActionResult<IEnumerable<FixtureDto>>> GetFixtureWithRelatedData(int id)
        {   
            var fixtureWithRelatedData = _context.Fixtures
                .Where(f => f.FixtureId == id) // Fetch Competition from Db, by Id
                .Include(f => f.TeamLineups)
                .Include(f => f.PlayersStatistics)  // Include related fixtures data,
                .Select(fixture => 
                    new FixtureDto{ // add the Fixture model data to the FixtureDto 
                    FixtureId = fixture.FixtureId,
                    SrSportEventId = fixture.SrSportEventId,
                    RoundNumber = fixture.RoundNumber,
                    StartTime = fixture.StartTime,
                    Status = fixture.Status,
                    HomeScore = fixture.HomeScore,
                    AwayScore = fixture.AwayScore,  
                    TeamLineups = fixture.TeamLineups.Select(teamLineup =>
                        new TeamLineupDto{
                        TeamLineupId = teamLineup.TeamLineupId,
                        Designation = teamLineup.Designation,
                        PlayerLineups = teamLineup.PlayerLineups.Select(playerLineups => 
                            new PlayerLineupDto{
                            PlayerLineupId = playerLineups.PlayerLineupId,
                            SrPlayerId = playerLineups.SrPlayerId,
                            JerseyNumber = playerLineups.JerseyNumber,
                            }).ToList(),    
                        }).ToList(),
                        
                    PlayersStatistics = fixture.PlayersStatistics.Select(playerStats =>
                        new PlayerStatisticsDto{
                        PlayerStatisticsId = playerStats.PlayerStatisticsId,
                        Tries = playerStats.Tries,
                        TryAssists = playerStats.TryAssists,
                        Conversions = playerStats.Conversions,
                        PenaltyGoals = playerStats.PenaltyGoals,
                        DropGoals = playerStats.DropGoals,
                        MetersRun = playerStats.MetersRun,
                        Carries = playerStats.Carries,
                        Passes = playerStats.Passes,
                        Offloads = playerStats.Offloads,
                        CleanBreaks = playerStats.CleanBreaks,
                        LineoutsWon = playerStats.LineoutsWon,
                        LineoutsLost = playerStats.LineoutsLost,
                        Tackles = playerStats.Tackles,
                        TacklesMissed = playerStats.TacklesMissed,
                        ScrumsWon = playerStats.ScrumsWon,
                        ScrumsLost = playerStats.ScrumsLost,
                        TotalScrums = playerStats.TotalScrums,
                        TurnoversWon = playerStats.TurnoversWon,
                        PenaltiesConceded = playerStats.PenaltiesConceded,
                        YellowCards = playerStats.YellowCards,
                        RedCards = playerStats.RedCards,
                        }).ToList(),
                }).ToList();

            return fixtureWithRelatedData;
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
        public async Task<ActionResult<Fixture>> PostFixture(Fixture fixture)
        {
            if (_context.Fixtures == null)
            {
                return Problem("Entity set 'RugbyDataDbContext.Fixtures'  is null.");
            }
            _context.Fixtures.Add(fixture);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FixtureExists(fixture.FixtureId) || FixtureExistsBySrid(fixture.SrSportEventId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFixture", new { id = fixture.FixtureId }, fixture);
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
        private bool FixtureExistsBySrid(string SrSportEventId)
        {
            return (_context.Fixtures?.Any(f => f.SrSportEventId == SrSportEventId)).GetValueOrDefault();
        }
    }
}
