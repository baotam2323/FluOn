using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP5.Data;
using ERP5.Models;
using System.Threading.Tasks;
using System;

namespace ERP5.Pages.InventoryItems
{
    public class EditModel : PageModel
    {
        private readonly Dbcontext _context;
        public EditModel(Dbcontext context) { _context = context; }

        [BindProperty]
        public InventoryItem InventoryItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            InventoryItem = await _context.InventoryItems.FindAsync(id);
            if (InventoryItem == null) return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            InventoryItem.UpdatedAt = DateTime.Now;
            _context.Attach(InventoryItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
