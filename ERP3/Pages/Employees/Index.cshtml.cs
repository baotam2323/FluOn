using ERP3.Data;
using ERP3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ERP3.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Models.Employee> Employees { get; set; } = new List<Models.Employee>();

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.AsNoTracking().ToListAsync();
        }
    }
}
