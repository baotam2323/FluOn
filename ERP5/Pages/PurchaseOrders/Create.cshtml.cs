using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP5.Pages.Admin.PurchaseOrders
{
    public class CreateModel : PageModel
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IInventoryService _inventoryService;

        public CreateModel(IPurchaseOrderService purchaseOrderService, IInventoryService inventoryService)
        {
            _purchaseOrderService = purchaseOrderService;
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public PurchaseOrder PurchaseOrder { get; set; }

        public IEnumerable<SelectListItem> InventoryItems { get; set; }

        public async Task OnGetAsync()
        {
            var items = await _inventoryService.GetAllAsync();
            InventoryItems = items.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();

            // Khởi tạo ít nhất 3 hàng item để nhập dữ liệu
            PurchaseOrder = new PurchaseOrder
            {
                Items = new List<PurchaseOrderItem>
                {
                    new PurchaseOrderItem(),
                    new PurchaseOrderItem(),
                    new PurchaseOrderItem()
                }
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            // Tính tổng tiền
            PurchaseOrder.TotalAmount = PurchaseOrder.Items.Sum(i => i.Quantity * i.UnitPrice);

            await _purchaseOrderService.AddAsync(PurchaseOrder);
            return RedirectToPage("Index");
        }
    }
}
