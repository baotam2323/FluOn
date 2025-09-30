using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Reports
{
    public class WarehouseReportModel : PageModel
    {
        private readonly IAccountingTransactionService _transactionService;
        private readonly IWarehouseService _warehouseService;

        public WarehouseReportModel(
            IAccountingTransactionService transactionService,
            IWarehouseService warehouseService)
        {
            _transactionService = transactionService;
            _warehouseService = warehouseService;
        }

        public List<WarehouseReportDto> Reports { get; set; } = new();
        public List<Models.Warehouse> Warehouses { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? WarehouseId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? FromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ToDate { get; set; }

        public async Task OnGetAsync()
        {
            // Lấy danh sách kho
            Warehouses = await _warehouseService.GetAllAsync();

            // Lấy danh sách giao dịch
            var transactions = await _transactionService.GetAllAsync();

            // Lọc theo WarehouseId
            if (WarehouseId.HasValue)
            {
                transactions = transactions
                    .Where(t => t.WarehouseId == WarehouseId.Value)
                    .ToList();
            }

            // Lọc theo khoảng ngày
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

            // Gom dữ liệu thành báo cáo
            Reports = transactions
                .GroupBy(t => t.WarehouseId)
                .Select(g => new WarehouseReportDto
                {
                    WarehouseId = (int)g.Key,
                    TotalTransactions = g.Count(),
                    TotalAmount = g.Sum(t => t.Amount)
                })
                .ToList();
        }
    }
}
