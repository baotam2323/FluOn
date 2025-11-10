using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.AccountingTransactions
{
    // 🔒 Chỉ người có vai trò Admin hoặc Accountant mới được xem báo cáo
    [Authorize(Roles = "Admin,Accountant")]
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
            // 1️⃣ Lấy danh sách kho cho dropdown
            Warehouses = await _warehouseService.GetAllAsync();

            // 2️⃣ Lấy danh sách tất cả giao dịch
            var allTransactions = await _transactionService.GetAllAsync();

            // 3️⃣ Lọc dữ liệu theo kho
            if (WarehouseId.HasValue)
            {
                allTransactions = allTransactions
                    .Where(t => t.WarehouseId == WarehouseId.Value)
                    .ToList();
            }

            // 4️⃣ Lọc theo khoảng thời gian
            if (FromDate.HasValue)
            {
                allTransactions = allTransactions
                    .Where(t => t.Date >= FromDate.Value)
                    .ToList();
            }

            if (ToDate.HasValue)
            {
                allTransactions = allTransactions
                    .Where(t => t.Date <= ToDate.Value)
                    .ToList();
            }

            // 5️⃣ Gán dữ liệu kết quả
            Transactions = allTransactions.OrderByDescending(t => t.Date).ToList();
        }
    }
}
