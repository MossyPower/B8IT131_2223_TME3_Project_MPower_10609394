using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcRugby.Mappings;
using MvcRugby.Models;

namespace MvcRugby.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Club> Clubs { get; set; } = default!;
    public DbSet<Competition> Competitions { get; set; } = null!;
    public DbSet<Fixture> Fixtures { get; set; } = null!;
    public DbSet<FixtureStatistics> FixturesStatistics { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
}
