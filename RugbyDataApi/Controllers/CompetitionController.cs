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
        
        // [HttpGet("withRelatedData")]
        // public async Task<ActionResult<IEnumerable<CompetitionDto>>> GetCompetitionsWithRelatedData()
        // {
        //     // Transfer Competitions & related data in a DTO, to 
        //     var competitionsWithRelatedData = _context.Competitions
        //         .Include(c => c.Fixtures)  // Include related fixtures
        //         .Include(c => c.Teams)    // Include related clubs
        //         .Select(c => new CompetitionDto
        //         {
        //             CompetitionId = c.CompetitionId,
        //             Competition_Name = c.Competition_Name,
        //             Fixtures = c.Fixtures.Select(fixture => new FixtureDto // add the Fixture model data to the FixtureDto 
        //                 {
        //                     FixtureId = fixture.FixtureId,
        //                     SportRadar_Id = fixture.SportRadar_Id,
        //                     Round_Number = fixture.Round_Number,
        //                     Fixture_Date = fixture.Fixture_Date,
        //                     FixturesStatistics = fixture.FixtureStatistics.Select(fs => new FixtureStatisticsDto{
        //                         FixtureStatisticsId = fs.FixtureStatisticsId,
        //                         SportRadar_Id = fs.SportRadar_Id,
        //                         Tries = fs.Tries,
        //                         Try_Assists = fs.Try_Assists,
        //                         Conversions = fs.Conversions,
        //                         Penalty_Goals = fs.Penalty_Goals,
        //                         Drop_Goals = fs.Drop_Goals,
        //                         Meters_Run = fs.Meters_Run,
        //                         Carries = fs.Carries,
        //                         Passes = fs.Passes,
        //                         Offloads = fs.Offloads,
        //                         Clean_Breaks = fs.Clean_Breaks,
        //                         Lineouts_Won = fs.Lineouts_Won,
        //                         Lineouts_Lost = fs.Lineouts_Lost,
        //                         Tackles = fs.Tackles,
        //                         Tackles_Missed = fs.Tackles_Missed,
        //                         Scrums_Won = fs.Scrums_Won,
        //                         Scrums_Lost = fs.Scrums_Lost,
        //                         Total_Scrums = fs.Total_Scrums,
        //                         Turnovers_Won = fs.Turnovers_Won,
        //                         Penalties_Conceded = fs.Penalties_Conceded,
        //                         Yellow_Cards = fs.Yellow_Cards,
        //                         Red_Cards = fs.Red_Cards,
        //                     }).ToList(),
        //                 })
        //                 .ToList(),
        //             Clubs = c.Clubs.Select(club => new ClubDto // add the Club model data to the ClubDto 
        //                 { 
        //                     ClubId = club.ClubId,
        //                     SportRadar_Competitor_Id = club.SportRadar_Competitor_Id,
        //                     Club_Name = club.Club_Name,
        //                     Players = club.Players.Select(player => new PlayerDto
        //                     {
        //                         PlayerId = player.PlayerId,
        //                         SportRadar_Id = player.SportRadar_Id,
        //                         First_Name = player.First_Name,
        //                         Last_Name = player.Last_Name,
        //                     })
        //                     .ToList(),
        //                 })
        //                 .ToList(),
        //         })
        //         .ToList();

        //     return competitionsWithRelatedData;
        // }
        
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
