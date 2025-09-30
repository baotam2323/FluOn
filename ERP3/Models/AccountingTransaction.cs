using System;
using System.ComponentModel.DataAnnotations;

namespace ERP3.Models
{
    public class AccountingTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; } = string.Empty; // Thu / Chi

        // ================== Foreign keys ==================
        public int? WarehouseId { get; set; }
        public int? LocationId { get; set; }
        public int? EmployeeId { get; set; }   // 🔹 Thêm dòng này

        // ================== Navigation ==================
        public Warehouse? Warehouse { get; set; }
        public Location? Location { get; set; }
        public Employee? Employee { get; set; }   // 🔹 Thêm navigation này

        // ================== Helper (read-only properties) ==================
        public string WarehouseName => Warehouse?.Name ?? "N/A";
        public string WarehouseAddress => Warehouse?.Address ?? "N/A";
        public string LocationName => Location?.Name ?? "N/A";
        public string EmployeeName => Employee?.Name ?? "N/A"; // 🔹 tiện hiển thị
    }
}
