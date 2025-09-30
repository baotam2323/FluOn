using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP3.Pages.AccountingTransactions
{
    public class ReportModel : PageModel
    {
        private readonly IAccountingTransactionService _transactionService;
        private readonly IWarehouseService _warehouseService;

        public ReportModel(
            IAccountingTransactionService transactionService,
            IWarehouseService warehouseService)
        {
            _transactionService = transactionService;
            _warehouseService = warehouseService;
        }

        public List<AccountingTransaction> Transactions { get; set; } = new();
        public List<Models.Warehouse> Warehouses { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? WarehouseId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? FromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ToDate { get; set; }

        public async Task OnGetAsync()
        {
            // lấy danh sách kho để đổ dropdown
            Warehouses = await _warehouseService.GetAllAsync();

            // lấy tất cả giao dịch
            var transactions = await _transactionService.GetAllAsync();

            // lọc theo kho
            if (WarehouseId.HasValue)
            {
                transactions = transactions
                    .Where(t => t.WarehouseId == WarehouseId.Value)
                    .ToList();
            }

            // lọc theo khoảng ngày
            if (FromDate.HasValue)
            {
                transactions = transactions
                    .Where(t => t.Date >= FromDate.Value)
                    .ToList();
            }

            if (ToDate.HasValue)
            {
                transactions = transactions
                    .Where(t => t.Date <= ToDate.Value)
                    .ToList();
            }

            Transactions = (List<AccountingTransaction>)transactions;
        }
    }
}

