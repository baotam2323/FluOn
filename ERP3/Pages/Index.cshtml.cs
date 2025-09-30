using ERP3.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ERP3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IEmployeeService _employeeService;
        private readonly IAccountingTransactionService _transactionService;
        private int count;

        public int TotalWarehouses { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalTransactions { get; set; }

        public IndexModel(
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
            var transactions = await _transactionService.GetAllAsync();

            TotalWarehouses = warehouses.Count;
            TotalEmployees = employees.Count;
            
            TotalTransactions = count;
        }
    }
}
