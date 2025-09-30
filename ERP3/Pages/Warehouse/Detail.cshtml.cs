using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP3.Data;
using ERP3.Models;

namespace ERP3.Pages.Warehouse
{
    public class DetailModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailModel(AppDbContext context)
        {
            _context = context;
        }

        public Models.Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Warehouse = await _context.Warehouses.FindAsync(id);

            if (Warehouse == null)
                return RedirectToPage("Index");

            return Page();
        }
    }
}
