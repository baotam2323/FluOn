using ERP3.Data;
using ERP3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ERP3.Pages.AccountingTransactions
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountingTransaction Transaction { get; set; } = default!;

        public SelectList Warehouses { get; set; } = default!;
        public SelectList Locations { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Transaction = await _context.AccountingTransactions
                                        .Include(t => t.Warehouse)
                                        .Include(t => t.Location)
                                        .FirstOrDefaultAsync(t => t.Id == id);

            if (Transaction == null)
            {
                return NotFound();
            }

            Warehouses = new SelectList(_context.Warehouses, "Id", "Name", Transaction.WarehouseId);
            Locations = new SelectList(_context.Locations, "Id", "Name", Transaction.LocationId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Warehouses = new SelectList(_context.Warehouses, "Id", "Name", Transaction.WarehouseId);
                Locations = new SelectList(_context.Locations, "Id", "Name", Transaction.LocationId);
                return Page();
            }

            // Check FK
            bool warehouseExists = await _context.Warehouses.AnyAsync(w => w.Id == Transaction.WarehouseId);
            bool locationExists = await _context.Locations.AnyAsync(l => l.Id == Transaction.LocationId);

            if (!warehouseExists)
            {
                ModelState.AddModelError("Transaction.WarehouseId", "Kho không tồn tại.");
            }
            if (!locationExists)
            {
                ModelState.AddModelError("Transaction.LocationId", "Vị trí không tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                Warehouses = new SelectList(_context.Warehouses, "Id", "Name", Transaction.WarehouseId);
                Locations = new SelectList(_context.Locations, "Id", "Name", Transaction.LocationId);
                return Page();
            }

            _context.Attach(Transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
