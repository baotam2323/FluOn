using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Pages.Employees
{
    [Authorize(Roles = "Admin")] // Chỉ Admin mới được xem danh sách nhân viên
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IList<Models.Employee> Employees { get; set; } = new List<Models.Employee>();

        public async Task OnGetAsync()
        {
            Employees = await _employeeService.GetAllAsync();
        }
    }
}
