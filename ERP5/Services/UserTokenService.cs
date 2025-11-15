using ERP5.Data;
using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP5.Services.Implementations
{
    public class UserTokenService : IUserTokenService
    {
        private readonly Dbcontext _context;

        public UserTokenService(Dbcontext context)
        {
            _context = context;
        }

        public async Task<decimal> GetUserBalanceAsync(string userId)
        {
            var logs = await _context.TokenLogs
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return logs.Sum(l => l.Amount);
        }

        public async Task BuyTokensAsync(string userId, decimal amount)
        {
            var log = new TokenLog
            {
                UserId = userId,
                Amount = (int)amount,
                Type = "Buy",
                Date = DateTime.Now
            };
            _context.TokenLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TokenLog>> GetUserLogsAsync(string userId)
        {
            return await _context.TokenLogs
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<List<TokenLog>> GetAllLogsAsync()
        {
            return await _context.TokenLogs
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }
    }
}
