using ERP5.Data;
using ERP5.Models;

public interface IInventoryService
{
    Task<IList<InventoryItem>> GetAllAsync();
    Task<InventoryItem> GetByIdAsync(int id);
    Task AddAsync(InventoryItem item);
    Task UpdateAsync(InventoryItem item);
    Task DeleteAsync(InventoryItem item);
    Task<List<ERP5.Models.Shipment>> GetAllShipmentsAsync();
    Task<ERP5.Models.Shipment> GetShipmentByTrackingNumberAsync(string trackingNumberFilter);
    Task<List<ERP5.Models.Shipment>> GetShipmentsByStatusAsync(string statusFilter);
    Task<List<InventoryItem>> GetAllItemsAsync();
    Task ImportItemAsync(InventoryItem importItem);
    Task<List<InventoryItem>> GetStorageItemsAsync();
    Task ExportItemAsync(InventoryItem exportItem);
}
