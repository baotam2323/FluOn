using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP3.Pages.Transactions
{
    public class EditModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly IWarehouseService _warehouseService;

        public EditModel(ITransactionService transactionService, IWarehouseService warehouseService)
        {
            _transactionService = transactionService;
            _warehouseService = warehouseService;
        }

        [BindProperty]
        public Transaction Transaction { get; set; } = new();

        public List<Models.Warehouse> Warehouses { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Transaction = await _transactionService.GetByIdAsync(id);
            if (Transaction == null) return NotFound();

            Warehouses = await _warehouseService.GetAllAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Warehouses = await _warehouseService.GetAllAsync();
                return Page();
            }

            await _transactionService.UpdateAsync(Transaction);
            return RedirectToPage("Index");
        }
    }
}
