using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP5.Data;
using ERP5.Models;

namespace ERP5.Pages.UserTokens
{
    public class CreateModel : PageModel
    {
        private readonly Dbcontext _context;
        public CreateModel(Dbcontext context) { _context = context; }

        [BindProperty]
        public UserToken UserToken { get; set; }
        public SelectList UserList { get; set; }

        public async Task OnGetAsync()
        {
            var users = await _context.Users.ToListAsync();
            UserList = new SelectList(users, "Id", "FullName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.UserTokens.Add(UserToken);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
