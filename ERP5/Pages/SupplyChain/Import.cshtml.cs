using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP5.Pages.SupplyChain
{
    [Authorize(Roles = "Employee")]
    public class ImportModel : PageModel
    {
        private readonly IInventoryService _inventoryService;
        public ImportModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public InventoryItem ImportItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _inventoryService.ImportItemAsync(ImportItem);
            return RedirectToPage("/Inventory/Index");
        }
    }
}
