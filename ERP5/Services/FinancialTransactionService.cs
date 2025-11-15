using ERP5.Data;
using ERP5.Models;
using Microsoft.EntityFrameworkCore;

public interface IFinancialTransactionService
{
    Task<IList<FinancialTransaction>> GetAllAsync();
    Task<FinancialTransaction> GetByIdAsync(int id);
    Task AddAsync(FinancialTransaction transaction);
    Task UpdateAsync(FinancialTransaction transaction);
    Task DeleteAsync(FinancialTransaction transaction);
}

public class FinancialTransactionService : IFinancialTransactionService
{
    private readonly Dbcontext _context;
    public FinancialTransactionService(Dbcontext context) { _context = context; }

    public async Task<IList<FinancialTransaction>> GetAllAsync()
        => await _context.FinancialTransactions.ToListAsync();

    public async Task<FinancialTransaction> GetByIdAsync(int id)
        => await _context.FinancialTransactions.FindAsync(id);

    public async Task AddAsync(FinancialTransaction transaction)
    {
        _context.FinancialTransactions.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FinancialTransaction transaction)
    {
        _context.FinancialTransactions.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(FinancialTransaction transaction)
    {
        _context.FinancialTransactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}
