using Microsoft.EntityFrameworkCore;
using Cavavin.API.Data;
using Cavavin.API.Interfaces;
using Cavavin.API.Models;

namespace Cavavin.API.Repositories;


public class WineRepository : IWineRepository 
{
    private readonly AppDbContext _context;

    public WineRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WineBottle>> GetAllAsync() => 
        await _context.WineBottles.ToListAsync();

    public async Task<WineBottle?> GetByIdAsync(int id) => 
        await _context.WineBottles.FindAsync(id);

    public async Task CreateAsync(WineBottle wine)
    {
        await _context.WineBottles.AddAsync(wine);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(WineBottle wine)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        var wine = await GetByIdAsync(id);
        if (wine != null)
        {
            _context.WineBottles.Remove(wine);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ExistsAsync(int id)
    {
        throw new NotImplementedException();
    }
}