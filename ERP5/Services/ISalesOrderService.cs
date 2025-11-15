using ERP5.Models;

namespace ERP5.Services.Interfaces
{
    public interface ISalesOrderService
    {
        Task<IList<SalesOrder>> GetAllAsync();
        Task<SalesOrder> GetByIdAsync(int id);
        Task AddAsync(SalesOrder order);
        Task UpdateAsync(SalesOrder order);
        Task DeleteAsync(SalesOrder order);
    }
}
