using Microsoft.EntityFrameworkCore;

namespace RugbyDataApi.Data;

public class RugbyDataContext : DbContext
{
    public RugbyDataContext(DbContextOptions<RugbyDataContext> options)
        : base(options)
    {
    }

    public DbSet<RugbyDataItem> RugbyDataItems { get; set; } = null!;
}