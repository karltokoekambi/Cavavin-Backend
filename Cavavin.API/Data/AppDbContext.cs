using Microsoft.EntityFrameworkCore;
using Cavavin.API.Models;

namespace Cavavin.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<WineBottle> WineBottles { get; set; }
}