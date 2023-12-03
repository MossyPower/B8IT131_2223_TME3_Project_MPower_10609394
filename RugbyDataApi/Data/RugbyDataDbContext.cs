using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Models;

namespace RugbyDataApi.Data
{
    public class RugbyDataDbContext : DbContext
    {
        public RugbyDataDbContext(DbContextOptions<RugbyDataDbContext> options) :
        base(options)
        {}
        public DbSet<Seasons> seasons { get; set; } = null!;
        public DbSet<SeasonLineups> seasonLineups { get; set; } = null!;
        public DbSet<Players> players { get; set; } = null!;
    }
}