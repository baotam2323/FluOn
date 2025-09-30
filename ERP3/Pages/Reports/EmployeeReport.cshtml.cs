using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Reports
{
    public class EmployeeReportModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAccountingTransactionService _transactionService;

        public EmployeeReportModel(IEmployeeService employeeService, IAccountingTransactionService transactionService)
        {
            _employeeService = employeeService;
            _transactionService = transactionService;
        }

        public List<EmployeeReportDto> Reports { get; set; } = new();

        public async Task OnGetAsync()
        {
            var employees = await _employeeService.GetAllAsync();
            var transactions = await _transactionService.GetAllAsync();

            Reports = employees.Select(e => new EmployeeReportDto
            {
                EmployeeName = e.Name,
                TotalIncome = transactions
                    .Where(t => t.EmployeeId == e.Id && t.Amount > 0)
                    .Sum(t => t.Amount),
                TotalExpense = transactions
                    .Where(t => t.EmployeeId == e.Id && t.Amount < 0)
                    .Sum(t => -t.Amount),
                Balance = transactions
                    .Where(t => t.EmployeeId == e.Id)
                    .Sum(t => t.Amount)
            }).ToList();
        }
    }
}

