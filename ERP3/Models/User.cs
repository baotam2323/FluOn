using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ERP3.Models
{
    public class User : IdentityUser
    {
        [Required]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Chức vụ")]
        public string? Role { get; set; }

        [Display(Name = "Bộ phận")]
        public string? Department { get; set; }
    }
}
