using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP5.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        // Role: Admin, Staff, Customer
        [MaxLength(20)]
        public string Role { get; set; }

        // Quan hệ với các bảng khác
        public ICollection<FinancialTransaction> FinancialTransactions { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
        public ICollection<InventoryItem> ManagedInventoryItems { get; set; }
        public ICollection<PurchaseOrder> CreatedPurchaseOrders { get; set; }
        public ICollection<SalesOrder> CreatedSalesOrders { get; set; }
        public ICollection<Invoice> CreatedInvoices { get; set; }
        public ICollection<WarehouseTransaction> WarehouseTransactions { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
