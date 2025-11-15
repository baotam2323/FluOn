using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ERP5.Pages.Admin.SalesOrders
{
    [Authorize(Roles = "Admin,Employee")]
    public class IndexModel : PageModel
    {
        private readonly ISalesOrderService _salesOrderService;

        public IndexModel(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        public IList<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();

        public async Task OnGetAsync()
        {
            SalesOrders = await _salesOrderService.GetAllAsync();
        }
    }
}
