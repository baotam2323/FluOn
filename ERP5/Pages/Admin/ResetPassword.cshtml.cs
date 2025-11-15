using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP5.Models;

namespace ERP5.Pages.Admin
{
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string UserName { get; set; } = "";

        [BindProperty]
        public string NewPassword { get; set; } = "";

        public string Message { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                Message = "User không tồn tại!";
                return Page();
            }

            // Reset password trực tiếp bằng PasswordHasher
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, NewPassword);

            if (result.Succeeded)
            {
                Message = $"Đã reset password cho {UserName} thành công!";
            }
            else
            {
                Message = "Có lỗi xảy ra: " + string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return Page();
        }
    }
}
