using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP5.Data;
using ERP5.Models;

namespace ERP5.Pages.UserTokens
{
    public class EditModel : PageModel
    {
        private readonly Dbcontext _context;
        public EditModel(Dbcontext context) { _context = context; }

        [BindProperty]
        public UserToken UserToken { get; set; }
        public SelectList UserList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            UserToken = await _context.UserTokens.FindAsync(id);
            if (UserToken == null) return NotFound();

            var users = await _context.Users.ToListAsync();
            UserList = new SelectList(users, "Id", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var users = await _context.Users.ToListAsync();
                UserList = new SelectList(users, "Id", "FullName");
                return Page();
            }

            _context.UserTokens.Update(UserToken);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
