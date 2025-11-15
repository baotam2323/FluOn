using System;

namespace ERP5.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Mô tả món hàng
        public string Description { get; set; } = string.Empty;

        // Đơn vị
        public string Unit { get; set; } = string.Empty;

        // Số lượng
        public int Quantity { get; set; }

        // Giá đơn vị
        public decimal UnitPrice { get; set; }

        // Ngày tạo
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Ngày cập nhật cuối
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public string Location { get; set; } = "Warehouse A";
        public DateTime UpdatedAt { get; internal set; }
    }
}
