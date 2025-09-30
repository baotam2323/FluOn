using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP3.Pages.AccountingTransactions
{
    public class TaxReportModel : PageModel
    {
        private readonly IAccountingTransactionService _transactionService;
        private readonly IWarehouseService _warehouseService;

        public TaxReportModel(IAccountingTransactionService transactionService, IWarehouseService warehouseService)
        {
            _transactionService = transactionService;
            _warehouseService = warehouseService;
        }

        public List<TaxReportDto> TaxReports { get; set; } = new();

        public async Task OnGetAsync()
        {
            var transactions = await _transactionService.GetAllAsync();
            var warehouses = await _warehouseService.GetAllAsync();

            const decimal taxRate = 0.1m; // giả sử 10% thuế

            TaxReports = warehouses.Select(w =>
            {
                var whTransactions = transactions.Where(t => t.WarehouseId == w.Id);
                var totalIncome = whTransactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
                var totalExpense = whTransactions.Where(t => t.Amount < 0).Sum(t => -t.Amount);
                var taxableIncome = totalIncome - totalExpense;
                var taxAmount = taxableIncome * taxRate;

                return new TaxReportDto
                {
                    WarehouseName = w.Name,
                    TotalIncome = totalIncome,
                    TotalExpense = totalExpense,
                    TaxableIncome = taxableIncome,
                    TaxAmount = taxAmount
                };
            }).ToList();
        }
    }
}
