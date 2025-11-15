using ERP5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP5.Pages.Admin
{
    public class ChangeRoleModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ChangeRoleModel(UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<ApplicationUser> Users { get; set; }
        public IList<IdentityRole> Roles { get; set; }

        [BindProperty]
        public string SelectedUserId { get; set; }
        [BindProperty]
        public string SelectedRole { get; set; }

        public async Task OnGetAsync()
        {
            Users = await Task.FromResult(_userManager.Users.ToList());
            Roles = await Task.FromResult(_roleManager.Roles.ToList());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(SelectedUserId) || string.IsNullOrEmpty(SelectedRole))
                return RedirectToPage();

            var user = await _userManager.FindByIdAsync(SelectedUserId);
            if (user == null)
                return RedirectToPage();

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, SelectedRole);

            return RedirectToPage();
        }
    }
}
