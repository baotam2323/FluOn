using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace ERP5.Pages.Admin.SalesOrders
{
    public class EditModel : PageModel
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(ISalesOrderService salesOrderService, UserManager<ApplicationUser> userManager)
        {
            _salesOrderService = salesOrderService;
            _userManager = userManager;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SalesOrder = await _salesOrderService.GetByIdAsync(id);
            if (SalesOrder == null) return NotFound();

            var users = _userManager.Users;
            Customers = users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName
            }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var users = _userManager.Users;
                Customers = users.Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                }).ToList();
                return Page();
            }

            // Tính lại TotalAmount
            SalesOrder.TotalAmount = SalesOrder.Items.Sum(i => i.Quantity * i.UnitPrice);

            await _salesOrderService.UpdateAsync(SalesOrder);
            return RedirectToPage("Index");
        }
    }
}
