using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Warehouse
{
    public class IndexModel : PageModel
    {
        private readonly IWarehouseService _service;
        public IndexModel(IWarehouseService service) => _service = service;

        public List<Models.Warehouse> Warehouses { get; set; } = new();

        public async Task OnGetAsync()
        {
            Warehouses = await _service.GetAllAsync();
        }
    }
}
