using ERP3.Models;

namespace ERP3.Services
{
    public interface IWarehouseService
    {
        Task<List<Warehouse>> GetAllAsync();
        Task<Warehouse?> GetByIdAsync(int id);
        Task AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
    }
}
