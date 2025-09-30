using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Pages.Transactions
{
    public class CreateModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly IWarehouseService _warehouseService;

        public CreateModel(ITransactionService transactionService, IWarehouseService warehouseService)
        {
            _transactionService = transactionService;
            _warehouseService = warehouseService;
        }

        [BindProperty]
        public Transaction Transaction { get; set; } = new();

        public List<Models.Warehouse> Warehouses { get; set; } = new();

        public async Task OnGetAsync()
        {
            Warehouses = await _warehouseService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Warehouses = await _warehouseService.GetAllAsync();
                return Page();
            }

            await _transactionService.AddAsync(Transaction);
            return RedirectToPage("Index");
        }
    }
}
