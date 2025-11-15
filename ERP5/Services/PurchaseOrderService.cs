using ERP5.Data;
using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP5.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly Dbcontext _context;

        public PurchaseOrderService(Dbcontext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseOrder>> GetAllAsync()
        {
            return await _context.PurchaseOrders
                                 .Include(po => po.Items)
                                 .ToListAsync();
        }

        public async Task<PurchaseOrder> GetByIdAsync(int id)
        {
            return await _context.PurchaseOrders
                                 .Include(po => po.Items)
                                 .FirstOrDefaultAsync(po => po.Id == id);
        }

        public async Task AddAsync(PurchaseOrder order)
        {
            _context.PurchaseOrders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseOrder order)
        {
            _context.PurchaseOrders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PurchaseOrder order)
        {
            _context.PurchaseOrders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public Task<List<PurchaseOrder>> GetAllPurchaseOrdersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
