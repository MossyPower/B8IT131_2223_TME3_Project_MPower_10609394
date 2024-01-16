using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Models;

namespace RugbyDataApi.Data
{
    public class RugbyDataDbContext : DbContext
    {
        public RugbyDataDbContext(DbContextOptions<RugbyDataDbContext> options) :
        base(options)
        {}
        public DbSet<Club> Club { get; set; } = default!;
        public DbSet<Competition> Competition { get; set; } = null!;
        public DbSet<Fixture> Fixture { get; set; } = null!;
        public DbSet<FixtureStatistics> FixtureStatistics { get; set; } = null!;
        public DbSet<Player> Player { get; set; } = null!;
    }
}