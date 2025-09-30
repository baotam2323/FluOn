using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Warehouse
{
    public class CreateModel : PageModel
    {
        private readonly IWarehouseService _service;
        public CreateModel(IWarehouseService service) => _service = service;

        [BindProperty]
        public Models.Warehouse Warehouse { get; set; } = new();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _service.AddAsync(Warehouse);
            return RedirectToPage("Index");
        }
    }
}
