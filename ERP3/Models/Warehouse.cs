using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP3.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên kho bắt buộc nhập")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ bắt buộc nhập")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sức chứa bắt buộc nhập")]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        // Navigation
        public ICollection<AccountingTransaction> AccountingTransactions { get; set; } = new List<AccountingTransaction>();
    }
}
