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

        modelBuilder.Entity<WineBottle>().HasData(
            new WineBottle
            {
                Id = 1,
                Name = "Chateau Margaux",
                Domain = "Chateau Margaux",
                Vintage = 2015,
                StartMaturity = 2025,
                EndMaturity = 2050,
                Region = WineRegion.Bordeaux,
                Type = WineType.Red,
                FoodPairingKeywords = "agneau,gibier,boeuf",
                IsFavorite = true,
                Quantity = 3
            },
            new WineBottle
            {
                Id = 2,
                Name = "Cuvee des Enchanteleurs",
                Domain = "Mailly Grand Cru",
                Vintage = 2012,
                StartMaturity = 2020,
                EndMaturity = 2035,
                Region = WineRegion.Champagne,
                Type = WineType.Sparkling,
                FoodPairingKeywords = "aperitif,huitres,crevettes",
                IsFavorite = false,
                Quantity = 6
            },
            new WineBottle
            {
                Id = 3,
                Name = "Sancerre d'Antan",
                Domain = "Henri Bourgeois",
                Vintage = 2021,
                StartMaturity = 2023,
                EndMaturity = 2028,
                Region = WineRegion.Loire,
                Type = WineType.White,
                FoodPairingKeywords = "poisson,chevre,volaille",
                IsFavorite = true,
                Quantity = 4
            },
            new WineBottle
            {
                Id = 4,
                Name = "Cote Rotie La Mouline",
                Domain = "E. Guigal",
                Vintage = 2018,
                StartMaturity = 2026,
                EndMaturity = 2045,
                Region = WineRegion.Rhone,
                Type = WineType.Red,
                FoodPairingKeywords = "viande rouge,agneau,truffes",
                IsFavorite = true,
                Quantity = 2
            }
            );
    }
}