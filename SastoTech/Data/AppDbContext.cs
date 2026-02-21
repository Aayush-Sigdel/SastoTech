using Microsoft.EntityFrameworkCore;
using SastoTech.Models;

namespace SastoTech.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Laptops> Laptops { get; set; }
    public DbSet<Mobiles> Mobiles { get; set; }
}