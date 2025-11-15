using ERP5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP5.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ResetInvalidPasswordsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetInvalidPasswordsModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string UserId { get; set; }
        [BindProperty]
        public string NewPassword { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                Message = "User not found!";
                return Page();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, NewPassword);

            Message = result.Succeeded ? "Password reset successfully!" : "Failed to reset password.";
            return Page();
        }
    }
}
