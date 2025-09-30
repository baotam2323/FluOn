using ERP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Services
{
    public interface IAccountingService
    {
        Task<List<AccountingTransaction>> GetAllTransactionsAsync();
        Task<AccountingTransaction?> GetTransactionByIdAsync(int id);
        Task AddTransactionAsync(AccountingTransaction transaction);
        Task UpdateTransactionAsync(AccountingTransaction transaction);
        Task DeleteTransactionAsync(int id);

        // Thêm các method report nếu cần
        Task<decimal> GetTotalIncomeAsync();
        Task<decimal> GetTotalExpenseAsync();
        Task<decimal> GetNetProfitAsync();
    }
}
