using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Models;

namespace RugbyDataApi.Data
{
    public class RugbyDataDbContext : DbContext
    {
        public RugbyDataDbContext(DbContextOptions<RugbyDataDbContext> options) :
        base(options)
        {}
        public DbSet<Competition> Competitions { get; set; } = default!;
        public DbSet<Fixture> Fixtures { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerLineup> PlayerLineups { get; set; } = null!;
        public DbSet<PlayerStatistics> PlayersStatistics { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamLineup> TeamLineups { get; set; } = null!;
    }
}