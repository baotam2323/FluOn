using ERP3.Models;

namespace ERP3.Services
{
    public interface IAccountingTransactionService
    {
        Task<List<AccountingTransaction>> GetAllAsync();
        Task<AccountingTransaction?> GetByIdAsync(int id);
        Task AddAsync(AccountingTransaction transaction);
        Task UpdateAsync(AccountingTransaction transaction);
        Task DeleteAsync(int id);

        // Dropdown data
        Task<List<Warehouse>> GetWarehousesAsync();
        Task<List<Employee>> GetEmployeesAsync();

        // Optional: đếm tổng số transaction
        Task<int> GetCountAsync();
    }
}
