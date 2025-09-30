using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Reports
{
    public class FinanceReportModel : PageModel
    {
        private readonly IAccountingTransactionService _transactionService;

        public FinanceReportModel(IAccountingTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance => TotalIncome - TotalExpense;

        public async Task OnGetAsync()
        {
            var transactions = await _transactionService.GetAllAsync();

            TotalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
            TotalExpense = transactions.Where(t => t.Amount < 0).Sum(t => -t.Amount);
        }
    }
}

