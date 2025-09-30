using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP3.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mô tả bắt buộc nhập")]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số tiền bắt buộc nhập")]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ngày giao dịch bắt buộc nhập")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Loại giao dịch bắt buộc nhập")]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty; // Thu | Chi

        // --- Mới, sẽ tạo cột trong DB ---
        [Required(ErrorMessage = "Tên kho bắt buộc nhập")]
        [StringLength(200)]
        public string WarehouseName { get; set; } = string.Empty;

        [StringLength(200)]
        public string WarehouseAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vị trí bắt buộc nhập")]
        [StringLength(200)]
        public string LocationName { get; set; } = string.Empty;

        // --- DB navigation ---
        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
