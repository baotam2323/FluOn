using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ERP5.Pages.Admin.FinancialTransactions
{
    [Authorize(Roles = "Admin,Employee")]
    public class DeleteModel : PageModel
    {
        private readonly IFinancialTransactionService _transactionService;

        public DeleteModel(IFinancialTransactionService transactionService)
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
            if (Transaction == null)
                return NotFound();

            await _transactionService.DeleteAsync(Transaction);
            return RedirectToPage("Index");
        }
    }
}
