using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ERP5.Pages.Admin.FinancialTransactions
{
    [Authorize(Roles = "Admin,Employee")]
    public class EditModel : PageModel
    {
        private readonly IFinancialTransactionService _transactionService;

        public EditModel(IFinancialTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [BindProperty]
        public Models.FinancialTransaction Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Transaction = await _transactionService.GetByIdAsync(id);
            if (Transaction == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _transactionService.UpdateAsync(Transaction);
            return RedirectToPage("Index");
        }
    }
}
