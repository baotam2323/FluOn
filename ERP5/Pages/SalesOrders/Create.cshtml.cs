using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace ERP5.Pages.Admin.SalesOrders
{
    public class CreateModel : PageModel
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(ISalesOrderService salesOrderService, UserManager<ApplicationUser> userManager)
        {
            _salesOrderService = salesOrderService;
            _userManager = userManager;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }

        public async Task OnGetAsync()
        {
            var users = _userManager.Users;
            Customers = users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            SalesOrder.TotalAmount = 0; // ban đầu chưa có item
            await _salesOrderService.AddAsync(SalesOrder);

            return RedirectToPage("Index");
        }
    }
}
