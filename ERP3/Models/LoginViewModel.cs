using System.ComponentModel.DataAnnotations;

namespace ERP3.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email hoặc tên đăng nhập không được để trống.")]
        [Display(Name = "Email / Username")]
        public string UserNameOrEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Ghi nhớ đăng nhập")]
        public bool RememberMe { get; set; }
    }
}
