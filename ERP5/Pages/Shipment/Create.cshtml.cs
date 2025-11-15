using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP5.Models;
using ERP5.Services.Interfaces;

public class CreateModel : PageModel
{
    private readonly IShipmentService _service;

    public CreateModel(IShipmentService service)
    {
        _service = service;
    }

    [BindProperty]
    public Shipment Shipment { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _service.AddAsync(Shipment);
        return RedirectToPage("Index");
    }
}
