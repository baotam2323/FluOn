using ERP3.Data;
using ERP3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ERP3.Pages.Employee
{
    public class DetailModel : PageModel
    {
        private readonly AppDbContext _context;

        public Models.Employee Employee { get; set; } = new Models.Employee();

        public DetailModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (emp == null)
            {
                return NotFound();
            }

            Employee = emp;
            return Page();
        }
    }
}
