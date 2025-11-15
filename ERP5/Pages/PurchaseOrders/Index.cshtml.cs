using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP5.Pages.PurchaseOrders
{
    [Authorize(Roles = "Employee")]
    public class IndexModel : PageModel
    {
        private readonly IPurchaseOrderService _poService;
        public IndexModel(IPurchaseOrderService poService)
        {
            _poService = poService;
        }

        public List<PurchaseOrder> Orders { get; set; }

        public async Task OnGetAsync()
        {
            Orders = await _poService.GetAllPurchaseOrdersAsync();
        }
    }
}
