using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP5.Models
{
    public class SalesOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderNumber { get; set; }  // Số đơn hàng, ví dụ "SO-001"

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now; // Ngày tạo đơn

        [Required]
        public string CustomerId { get; set; }   // Liên kết với ApplicationUser

        public ApplicationUser Customer { get; set; }

        public decimal TotalAmount { get; set; }  // Tổng tiền đơn hàng

        public List<SalesOrderItem> Items { get; set; } = new();
    }

    public class SalesOrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }

        [Required]
        public int InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }  // Giá đơn vị
    }
}
