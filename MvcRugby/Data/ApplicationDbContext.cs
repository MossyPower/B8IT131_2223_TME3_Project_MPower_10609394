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
    
    public DbSet<Club> Club { get; set; } = default!;
    public DbSet<Competition> Competition { get; set; } = null!;
    public DbSet<Fixture> Fixture { get; set; } = null!;
    public DbSet<FixtureStatistics> FixtureStatistics { get; set; } = null!;
    public DbSet<Player> Player { get; set; } = null!;
}
