using ERP5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP5.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<List<PurchaseOrder>> GetAllAsync();
        Task<PurchaseOrder> GetByIdAsync(int id);
        Task AddAsync(PurchaseOrder order);
        Task UpdateAsync(PurchaseOrder order);
        Task DeleteAsync(PurchaseOrder order);
        Task<List<PurchaseOrder>> GetAllPurchaseOrdersAsync();
    }
}
