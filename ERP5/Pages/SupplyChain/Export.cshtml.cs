using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP5.Pages.SupplyChain
{
    [Authorize(Roles = "Employee")]
    public class ExportModel : PageModel
    {
        private readonly IInventoryService _inventoryService;
        public ExportModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public InventoryItem ExportItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _inventoryService.ExportItemAsync(ExportItem);
            return RedirectToPage("/Inventory/Index");
        }
    }
}
