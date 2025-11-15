using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP5.Data;
using ERP5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP5.Pages.InventoryItems
{
    public class IndexModel : PageModel
    {
        private readonly Dbcontext _context;
        public IndexModel(Dbcontext context) { _context = context; }

        public IList<InventoryItem> InventoryItems { get; set; }
        public InventoryItem NewItem { get; set; } = new();

        public async Task OnGetAsync()
        {
            InventoryItems = await _context.InventoryItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.InventoryItems.Add(NewItem);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item != null)
            {
                _context.InventoryItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item != null)
            {
                item.Name = NewItem.Name;
                item.Description = NewItem.Description;
                item.Unit = NewItem.Unit;
                item.Quantity = NewItem.Quantity;
                item.UnitPrice = NewItem.UnitPrice;
                item.Location = NewItem.Location;
                item.LastUpdated = System.DateTime.Now;

                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
