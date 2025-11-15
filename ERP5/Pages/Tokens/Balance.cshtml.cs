using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ERP5.Pages.Tokens
{
    [Authorize]
    public class BalanceModel : PageModel
    {
        private readonly IUserTokenService _tokenService;

        public BalanceModel(IUserTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public decimal Balance { get; set; }

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Balance = await _tokenService.GetUserBalanceAsync(userId);
        }
    }
}
