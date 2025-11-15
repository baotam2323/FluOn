using ERP5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP5.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<List<Shipment>> GetAllShipmentsAsync();
        Task AddAsync(Shipment shipment);
        Task<Shipment> GetByIdAsync(int id);
        Task UpdateAsync(Shipment shipment);
        Task DeleteAsync(int id);
        Task<List<Shipment>> GetAllAsync();
    }
}
