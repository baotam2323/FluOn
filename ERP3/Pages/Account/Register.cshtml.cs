using ERP3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ERP3.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public RegisterModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không khớp.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [TempData]
        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
            Message = string.Empty;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingUser = await _userManager.FindByNameAsync(UserName);
            if (existingUser != null)
            {
                Message = "Tài khoản đã tồn tại!";
                return Page();
            }

            var user = new User
            {
                UserName = UserName,
                FullName = FullName
            };

            var result = await _userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                Message = "Đăng ký thành công! Bạn có thể đăng nhập ngay.";
                return RedirectToPage("/Account/Login");
            }
            else
            {
                Message = string.Join("; ", result.Errors.Select(e => e.Description));
                return Page();
            }
        }
    }
}
