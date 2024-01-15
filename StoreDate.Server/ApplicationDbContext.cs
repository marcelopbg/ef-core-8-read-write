using Microsoft.EntityFrameworkCore;

namespace StoreDate.Server;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<DateWrapper> Dates { get; set; }
}
