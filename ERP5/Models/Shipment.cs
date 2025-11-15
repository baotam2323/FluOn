using System;

namespace ERP5.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending, Shipped, Delivered
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ShippedAt { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;

        // Thêm Type để phân biệt Import / Export
        public string Type { get; set; } = "Import"; // "Import" hoặc "Export"
    }
}
