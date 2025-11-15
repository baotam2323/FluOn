using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP5.Data;
using ERP5.Models;
using System.Threading.Tasks;
using System;

namespace ERP5.Pages.InventoryItems
{
    public class CreateModel : PageModel
    {
        private readonly Dbcontext _context;
        public CreateModel(Dbcontext context) { _context = context; }

        [BindProperty]
        public InventoryItem InventoryItem { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.InventoryItems.Add(InventoryItem);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
