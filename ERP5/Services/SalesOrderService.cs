using ERP5.Data;
using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP5.Services.Implementations
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly Dbcontext _context;

        public SalesOrderService(Dbcontext context)
        {
            _context = context;
        }

        public async Task<IList<SalesOrder>> GetAllAsync()
        {
            return await _context.SalesOrders
                .Include(o => o.Items)
                    .ThenInclude(i => i.InventoryItem)
                .Include(o => o.Customer)
                .ToListAsync();
        }

        public async Task<SalesOrder> GetByIdAsync(int id)
        {
            return await _context.SalesOrders
                .Include(o => o.Items)
                    .ThenInclude(i => i.InventoryItem)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(SalesOrder order)
        {
            // Tính tổng tiền
            order.TotalAmount = order.Items.Sum(i => i.Quantity * i.UnitPrice);

            _context.SalesOrders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SalesOrder order)
        {
            order.TotalAmount = order.Items.Sum(i => i.Quantity * i.UnitPrice);

            _context.SalesOrders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SalesOrder order)
        {
            _context.SalesOrders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
