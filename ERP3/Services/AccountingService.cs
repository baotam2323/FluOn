using ERP3.Data;
using ERP3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Services
{
    public class AccountingService : IAccountingService
    {
        private readonly AppDbContext _context;

        public AccountingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountingTransaction>> GetAllTransactionsAsync()
        {
            return await _context.AccountingTransactions.ToListAsync();
        }

        public async Task<AccountingTransaction?> GetTransactionByIdAsync(int id)
        {
            return await _context.AccountingTransactions.FindAsync(id);
        }

        public async Task AddTransactionAsync(AccountingTransaction transaction)
        {
            _context.AccountingTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransactionAsync(AccountingTransaction transaction)
        {
            _context.AccountingTransactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var tran = await _context.AccountingTransactions.FindAsync(id);
            if (tran != null)
            {
                _context.AccountingTransactions.Remove(tran);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<decimal> GetTotalIncomeAsync()
        {
            return await _context.AccountingTransactions
                .Where(t => t.Type == "Thu")
                .SumAsync(t => (decimal?)t.Amount) ?? 0;
        }

        public async Task<decimal> GetTotalExpenseAsync()
        {
            return await _context.AccountingTransactions
                .Where(t => t.Type == "Chi")
                .SumAsync(t => (decimal?)t.Amount) ?? 0;
        }

        public async Task<decimal> GetNetProfitAsync()
        {
            var income = await GetTotalIncomeAsync();
            var expense = await GetTotalExpenseAsync();
            return income - expense;
        }
    }
}
