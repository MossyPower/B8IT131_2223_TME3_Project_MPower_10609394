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
        
        // Working with Data Model Objects ("DTOs"):
            // Microsoft website. Tutorial: Create a web API with ASP.NET Core. Available at:
            // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code 

            // Microsoft website. Create Data Transfer Objects (DTOs). Available at:
            // https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5 
        
        [HttpGet("withRelatedData/{id}")]
        public async Task<ActionResult<IEnumerable<CompetitionDto>>> GetCompetitionWithRelatedData(int id)
        {   
            var competitionsWithRelatedData = _context.Competitions
                .Where(c => c.CompetitionId == id) // Fetch Competition from Db, by Id
                .Include(c => c.Fixtures)  // Include related fixtures data,
                .Select(c => new CompetitionDto // add competition Db data to new CompetitionDto, on an attribute by attribute basis,
                {
                    CompetitionId = c.CompetitionId,
                    CompetitionName = c.CompetitionName,
                    Fixtures = c.Fixtures.Select(fixture => 
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
                    }).ToList(),
                }).ToList();

            return competitionsWithRelatedData;
        }
        
        // GET: api/Competition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(int id)
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
        public async Task<IActionResult> PutCompetition(int id, Competition competition)
        {
            if (id != competition.CompetitionId)
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
                if (CompetitionExists(competition.CompetitionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompetition", new { id = competition.CompetitionId }, competition);
        }

        // DELETE: api/Competition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(int id)
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

        private bool CompetitionExists(int id)
        {
            return (_context.Competitions?.Any(e => e.CompetitionId == id)).GetValueOrDefault();
        }
    }
}
