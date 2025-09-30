using ERP3.Data;
using ERP3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Employee Employee { get; set; } = new Models.Employee();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
