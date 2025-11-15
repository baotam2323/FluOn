using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP5.Pages.Admin.SalesOrders
{
    public class DeleteModel : PageModel
    {
        private readonly ISalesOrderService _salesOrderService;

        public DeleteModel(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SalesOrder = await _salesOrderService.GetByIdAsync(id);
            if (SalesOrder == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SalesOrder == null) return NotFound();
            await _salesOrderService.DeleteAsync(SalesOrder);
            return RedirectToPage("Index");
        }
    }
}
