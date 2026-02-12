using Microsoft.EntityFrameworkCore;
using Cavavin.API.Models;

namespace Cavavin.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<WineBottle> WineBottles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Conversion (Red -> "red")
        modelBuilder.Entity<WineBottle>()
            .Property(w => w.Type)
            .HasConversion(
                v => v.ToString().ToLower(),
                v => (WineType)Enum.Parse(typeof(WineType), v, true)
            );
        
        modelBuilder.Entity<WineBottle>()
            .Property(w => w.Region)
            .HasConversion(
                v => v.ToString().ToLower(),
                v => (WineRegion)Enum.Parse(typeof(WineRegion), v, true)
            );
    }
}