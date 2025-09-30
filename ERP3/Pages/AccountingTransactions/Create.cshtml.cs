using ERP3.Data;
using ERP3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP3.Pages.AccountingTransactions
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountingTransaction Transaction { get; set; } = new();

        // Dữ liệu cho dropdown
        public SelectList Warehouses { get; set; } = default!;
        public SelectList Locations { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Load dropdown
            Warehouses = new SelectList(await _context.Warehouses.AsNoTracking().ToListAsync(), "Id", "Name");
            Locations = new SelectList(await _context.Locations.AsNoTracking().ToListAsync(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Re-load dropdown khi post fail
            Warehouses = new SelectList(await _context.Warehouses.AsNoTracking().ToListAsync(), "Id", "Name");
            Locations = new SelectList(await _context.Locations.AsNoTracking().ToListAsync(), "Id", "Name");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra tồn tại WarehouseId và LocationId
            var warehouseExists = await _context.Warehouses.AnyAsync(w => w.Id == Transaction.WarehouseId);
            var locationExists = await _context.Locations.AnyAsync(l => l.Id == Transaction.LocationId);

            if (!warehouseExists)
            {
                ModelState.AddModelError("Transaction.WarehouseId", "Kho không hợp lệ");
                return Page();
            }

            if (!locationExists)
            {
                ModelState.AddModelError("Transaction.LocationId", "Vị trí không hợp lệ");
                return Page();
            }

            _context.AccountingTransactions.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
