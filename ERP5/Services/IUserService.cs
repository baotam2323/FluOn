using ERP5.Data;
using ERP5.Models;
using Microsoft.AspNetCore.Identity;

public interface IUserService
{
    Task<IList<ApplicationUser>> GetAllUsersAsync();
    Task<ApplicationUser> GetUserByIdAsync(string userId);
    Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password, string role);
    Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
    Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
    Task<IEnumerable<object>> GetActivityLogsAsync();
}
