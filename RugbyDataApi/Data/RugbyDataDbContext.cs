using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Models;

namespace RugbyDataApi.Data
{
    public class RugbyDataDbContext : DbContext
    {
        public RugbyDataDbContext(DbContextOptions<RugbyDataDbContext> options) :
        base(options)
        {}

        public DbSet<Season> Season { get; set; } = null!;
        
        public DbSet<Competition> Competition { get; set; } = null!;
        public DbSet<CompetitionRound> CompetitionRound { get; set; } = null!;
        public DbSet<CompetitionGame> CompetitionGame { get; set; } = null!;
        public DbSet<MatchDayTeam> MatchDayTeam { get; set; } = null!;

        public DbSet<Player> Player { get; set; } = null!;
        public DbSet<PlayerMatchStatistics> PlayerMatchStatistics { get; set; } = null!;
        public DbSet<RugbyDataApi.Models.Club> Club { get; set; } = default!;
    }
}