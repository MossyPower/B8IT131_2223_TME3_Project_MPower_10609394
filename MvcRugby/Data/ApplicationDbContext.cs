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
    public DbSet<Season> Season { get; set; } = null!;
    
    public DbSet<Competition> Competition { get; set; } = null!;
    public DbSet<CompetitionRound> CompetitionRound { get; set; } = null!;
    public DbSet<CompetitionGame> CompetitionGame { get; set; } = null!;
    public DbSet<MatchDayTeam> MatchDayTeam { get; set; } = null!;

    public DbSet<Player> Player { get; set; } = null!;
    public DbSet<PlayerMatchStatistics> PlayerMatchStatistics { get; set; } = null!;
    public DbSet<Club> Club { get; set; } = default!;
}
