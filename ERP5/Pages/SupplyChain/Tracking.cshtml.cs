using ERP5.Models;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP5.Pages.SupplyChain
{
    [Authorize(Roles = "Employee")]
    public class TrackingModel : PageModel
    {
        private readonly IShipmentService _shipmentService;

        public TrackingModel(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public List<Models.Shipment> Shipments { get; set; } = new List<Models.Shipment>();

        public async Task OnGetAsync()
        {
            Shipments = await _shipmentService.GetAllShipmentsAsync();
        }
    }
}
