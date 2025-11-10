using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using ERP3.Models;

namespace ERP3.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        // POST: /Account/Logout
        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                HttpContext.Session.Clear(); // Xóa tất cả session để tránh lỗi hiển thị tên cũ
            }

            return RedirectToPage("/Index"); // Redirect về trang chủ sau khi logout
        }
    }
}
