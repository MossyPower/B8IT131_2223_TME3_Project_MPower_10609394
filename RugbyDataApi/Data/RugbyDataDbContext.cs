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
    }
}