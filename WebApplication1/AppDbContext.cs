using Microsoft.EntityFrameworkCore;
using Shared;

namespace WebApplication1;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Customer>? Customers { get; set; }
}
