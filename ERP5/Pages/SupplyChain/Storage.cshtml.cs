using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP5.Pages.SupplyChain
{
    [Authorize(Roles = "Employee")]
    public class StorageModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public StorageModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public List<InventoryItem> StorageItems { get; set; }

        public async Task OnGetAsync()
        {
            StorageItems = await _inventoryService.GetStorageItemsAsync();
        }
    }
}
