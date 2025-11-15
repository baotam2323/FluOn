using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ERP5.Pages.Tokens
{
    [Authorize]
    public class BuyModel : PageModel
    {
        private readonly IUserTokenService _tokenService;

        public BuyModel(IUserTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [BindProperty]
        public decimal Amount { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Amount <= 0) return Page();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _tokenService.BuyTokensAsync(userId, Amount);
            Message = $"Successfully purchased {Amount} tokens!";
            return Page();
        }
    }
}
