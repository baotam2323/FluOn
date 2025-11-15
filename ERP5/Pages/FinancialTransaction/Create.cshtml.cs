using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ERP5.Pages.Admin.FinancialTransactions
{
    [Authorize(Roles = "Admin,Employee")]
    public class CreateModel : PageModel
    {
        private readonly IFinancialTransactionService _transactionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(IFinancialTransactionService transactionService, UserManager<ApplicationUser> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
        }

        [BindProperty]
        public Models.FinancialTransaction Transaction { get; set; }

        public void OnGet()
        {
            Transaction = new Models.FinancialTransaction
            {
                CreatedAt = DateTime.Now
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Lấy User hiện tại
            var user = await _userManager.GetUserAsync(User);
            Transaction.UserId = user.Id;

            await _transactionService.AddAsync(Transaction);
            return RedirectToPage("Index");
        }
    }
}
