using ERP5.Models;

namespace ERP5.Services.Interfaces
{
    public interface IUserTokenService
    {
        Task<decimal> GetUserBalanceAsync(string userId);
        Task BuyTokensAsync(string userId, decimal amount);
        Task<List<TokenLog>> GetUserLogsAsync(string userId); // <--- thêm phương thức này
        Task<List<TokenLog>> GetAllLogsAsync(); // nếu bạn muốn admin xem tất cả logs
    }
}
