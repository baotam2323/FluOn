using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP5.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Trạng thái đơn hàng (Pending, Approved, Completed)
        [Required]
        public string Status { get; set; } = "Pending";

        // Foreign Key Supplier
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; } // Navigation

        [Required]
        public string SupplierName { get; set; }

        public decimal TotalAmount { get; set; }

        public List<PurchaseOrderItem> Items { get; set; } = new();
    }

    public class PurchaseOrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        [Required]
        public int InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
