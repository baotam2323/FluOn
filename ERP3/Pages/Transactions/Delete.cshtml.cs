using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Transactions
{
    public class DeleteModel : PageModel
    {
        private readonly ITransactionService _transactionService;

        public DeleteModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [BindProperty]
        public Transaction Transaction { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Transaction = await _transactionService.GetByIdAsync(id);
            if (Transaction == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _transactionService.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
