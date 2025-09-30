using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.AccountingTransactions
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountingTransactionService _service;

        public DeleteModel(IAccountingTransactionService service)
        {
            _service = service;
        }

        [BindProperty]
        public AccountingTransaction Transaction { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            Transaction = transaction;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
