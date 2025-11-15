using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP5.Data;
using ERP5.Models;
using System.Threading.Tasks;
using System;

namespace ERP5.Pages.InventoryItems
{
    public class DeleteModel : PageModel
    {
        private readonly Dbcontext _context;
        public DeleteModel(Dbcontext context) { _context = context; }

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
            var item = await _context.InventoryItems.FindAsync(InventoryItem.Id);
            if (item != null)
            {
                _context.InventoryItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
