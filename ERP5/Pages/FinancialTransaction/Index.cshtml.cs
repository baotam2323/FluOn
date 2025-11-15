using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ERP5.Pages.Admin.FinancialTransactions
{
    [Authorize(Roles = "Admin,Employee")]
    public class IndexModel : PageModel
    {
        private readonly IFinancialTransactionService _transactionService;

        public IndexModel(IFinancialTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IList<Models.FinancialTransaction> Transactions { get; set; }

        public async Task OnGetAsync()
        {
            Transactions = await _transactionService.GetAllAsync();
        }
    }
}
