using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP5.Models;
using ERP5.Services.Interfaces;

public class IndexModel : PageModel
{
    private readonly IShipmentService _service;

    public IndexModel(IShipmentService service)
    {
        _service = service;
    }

    public List<Shipment> Shipments { get; set; } = new();

    public async Task OnGetAsync()
    {
        Shipments = await _service.GetAllAsync();
    }
}
