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
    [Route("api/v1/player/")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly RugbyDataDbContext _context;

        public PlayerController(RugbyDataDbContext context)
        {
            _context = context;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
          if (_context.Players == null)
          {
              return NotFound();
          }
            return await _context.Players.ToListAsync();
        }

        // GET: api/Player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }
        
        // GET: api/Player/5
        [HttpGet("/allfixtureplayers")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersByIds([FromQuery]List<int> ids)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            // get a list of all players by playerId (list of IDs passed in as param)
            var players = await _context.Players
                .Where(player => ids.Contains(player.PlayerId))
                .ToListAsync();

            if (players == null)
            {
                return NotFound();
            }

            return players;
        }
        
        //GET: list of all the PlayerLineups for each round, using a list of teamLineupIds
        [HttpGet("roundplayers")]
        public async Task<ActionResult<IEnumerable<Player>>> GetRoundPlayers([FromQuery] List<int> roundPlayersIds)
        {
            if (roundPlayersIds == null || roundPlayersIds.Count == 0)
            {
                return BadRequest("No fixture IDs provided");
            }

            var players = await _context.Players
                .Where(p => roundPlayersIds.Contains(p.PlayerId))  // return all Players in the Db if the playerId matches the list of playerIds provided
                .ToListAsync(); // Add all the Players found to a list

            if (players == null || players.Count == 0)
            {
                return NotFound("No team lineups found for the provided fixture IDs");
            }

            return players;
        }
        
        // PUT: api/Player/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Player
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            if (_context.Players == null)
            {
                return Problem("Entity set 'RugbyDataDbContext.Players' is null.");
            }
            _context.Players.Add(player);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerExists(player.PlayerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        // DELETE: api/Player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return (_context.Players?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
