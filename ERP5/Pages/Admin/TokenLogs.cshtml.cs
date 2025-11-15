using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP5.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class TokenLogsModel : PageModel
    {
        private readonly IUserTokenService _userTokenService;

        public TokenLogsModel(IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;
        }

        public List<TokenLog> Logs { get; set; } = new List<TokenLog>();

        public async Task OnGetAsync()
        {
            Logs = await _userTokenService.GetAllLogsAsync();
        }
    }
}
