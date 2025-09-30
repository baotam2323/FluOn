using ERP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(int id);
        Task AddAsync(Location location);
        Task UpdateAsync(Location location);
        Task DeleteAsync(int id);
    }
}
