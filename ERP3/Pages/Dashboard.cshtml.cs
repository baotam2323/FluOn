using ERP3.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ERP3.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IEmployeeService _employeeService;
        private readonly IAccountingTransactionService _transactionService;

        public int TotalWarehouses { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalTransactions { get; set; }

        public DashboardModel(
            IWarehouseService warehouseService,
            IEmployeeService employeeService,
            IAccountingTransactionService transactionService)
        {
            _warehouseService = warehouseService;
            _employeeService = employeeService;
            _transactionService = transactionService;
        }

        public async Task OnGetAsync()
        {
            var warehouses = await _warehouseService.GetAllAsync();
            var employees = await _employeeService.GetAllAsync();

            TotalWarehouses = warehouses?.Count ?? 0;
            TotalEmployees = employees?.Count ?? 0;
            TotalTransactions = await _transactionService.GetCountAsync(); // ✅ chỉ query COUNT
        }
    }
}


