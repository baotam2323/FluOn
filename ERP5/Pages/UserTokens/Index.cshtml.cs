using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP5.Data;
using ERP5.Models;

namespace ERP5.Pages.UserTokens
{
    public class IndexModel : PageModel
    {
        private readonly Dbcontext _context;
        public IndexModel(Dbcontext context) { _context = context; }

        public IList<UserToken> UserTokens { get; set; }

        public async Task OnGetAsync()
        {
            UserTokens = await _context.UserTokens
                .Include(u => u.User)
                .ToListAsync();
        }
    }
}
