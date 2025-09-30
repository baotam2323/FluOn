using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly ITransactionService _transactionService;

        public IndexModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public List<Transaction> Transactions { get; set; } = new();

        public async Task OnGetAsync()
        {
            Transactions = await _transactionService.GetAllAsync();
        }
    }
}
