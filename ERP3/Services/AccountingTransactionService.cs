using ERP3.Data;
using ERP3.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP3.Services
{
    public class AccountingTransactionService : IAccountingTransactionService
    {
        private readonly AppDbContext _context;

        public AccountingTransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountingTransaction>> GetAllAsync()
        {
            return await _context.AccountingTransactions
                .Include(t => t.Warehouse)
                .Include(t => t.Employee)
                .ToListAsync();
        }

        public async Task<AccountingTransaction?> GetByIdAsync(int id)
        {
            return await _context.AccountingTransactions
                .Include(t => t.Warehouse)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(AccountingTransaction transaction)
        {
            _context.AccountingTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AccountingTransaction transaction)
        {
            _context.AccountingTransactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.AccountingTransactions.FindAsync(id);
            if (entity != null)
            {
                _context.AccountingTransactions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.AccountingTransactions.CountAsync();
        }

        public async Task<List<Warehouse>> GetWarehousesAsync()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
