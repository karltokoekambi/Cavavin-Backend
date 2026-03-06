using Cavavin.API.Models;

namespace Cavavin.API.Interfaces;

public interface IWineRepository
{
    Task<IEnumerable<WineBottle>> GetAllAsync();
    Task<WineBottle?> GetByIdAsync(int id);
    Task CreateAsync(WineBottle wine);
    Task UpdateAsync(WineBottle wine);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}