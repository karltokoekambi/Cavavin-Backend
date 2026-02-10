using Microsoft.EntityFrameworkCore;
using Cavavin.API.Models;

namespace Cavavin.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // C'est ici qu'on déclare nos tables. 
    // Cette ligne créera une table "WineBottles" basée sur notre modèle.
    public DbSet<WineBottle> WineBottles { get; set; }
}