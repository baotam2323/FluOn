using Microsoft.EntityFrameworkCore;
using ERP5.Data;
using ERP5.Models;

public class InventoryService : IInventoryService
{
    private readonly Dbcontext _context;

    public InventoryService(Dbcontext context)
    {
        _context = context;
    }

    public async Task<IList<InventoryItem>> GetAllAsync()
    {
        return await _context.InventoryItems.ToListAsync();
    }

    public async Task<InventoryItem> GetByIdAsync(int id)
    {
        return await _context.InventoryItems.FindAsync(id);
    }

    public async Task AddAsync(InventoryItem item)
    {
        _context.InventoryItems.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(InventoryItem item)
    {
        _context.InventoryItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(InventoryItem item)
    {
        _context.InventoryItems.Remove(item);
        await _context.SaveChangesAsync();
    }

    public Task<List<Shipment>> GetAllShipmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ERP5.Models.Shipment> GetShipmentByTrackingNumberAsync(string trackingNumberFilter)
    {
        throw new NotImplementedException();
    }

    public Task<List<Shipment>> GetShipmentsByStatusAsync(string statusFilter)
    {
        throw new NotImplementedException();
    }

    Task<Shipment> IInventoryService.GetShipmentByTrackingNumberAsync(string trackingNumberFilter)
    {
        throw new NotImplementedException();
    }

    Task<List<Shipment>> IInventoryService.GetShipmentsByStatusAsync(string statusFilter)
    {
        throw new NotImplementedException();
    }

    public Task<List<InventoryItem>> GetAllItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task ImportItemAsync(InventoryItem importItem)
    {
        throw new NotImplementedException();
    }

    public Task<List<InventoryItem>> GetStorageItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task ExportItemAsync(InventoryItem exportItem)
    {
        throw new NotImplementedException();
    }
}
