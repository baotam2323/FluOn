using ERP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(int id);
    }
}
