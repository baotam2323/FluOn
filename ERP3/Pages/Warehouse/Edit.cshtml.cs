using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Warehouse
{
    public class EditModel : PageModel
    {
        private readonly IWarehouseService _service;
        public EditModel(IWarehouseService service) => _service = service;

        [BindProperty]
        public Models.Warehouse Warehouse { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var warehouse = await _service.GetByIdAsync(id);
            if (warehouse == null) return NotFound();
            Warehouse = warehouse;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _service.UpdateAsync(Warehouse);
            return RedirectToPage("Index");
        }
    }
}
