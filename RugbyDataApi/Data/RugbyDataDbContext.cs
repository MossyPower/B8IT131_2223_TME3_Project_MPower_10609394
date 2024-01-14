using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Models;

namespace RugbyDataApi.Data
{
    public class RugbyDataDbContext : DbContext
    {
        public RugbyDataDbContext(DbContextOptions<RugbyDataDbContext> options) :
        base(options)
        {}

        public DbSet<Season> Seasons { get; set; } = null!;
        
        public DbSet<Competition> Competitions { get; set; } = null!;
        public DbSet<CompetitionRound> CompetitionRounds { get; set; } = null!;
        public DbSet<CompetitionGame> CompetitionGames { get; set; } = null!;
        public DbSet<MatchDayTeam> MatchDayTeams { get; set; } = null!;

        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerMatchStatistics> PlayersMatchStatistics { get; set; } = null!;
        public DbSet<RugbyDataApi.Models.Club> Club { get; set; } = default!;
    }
}