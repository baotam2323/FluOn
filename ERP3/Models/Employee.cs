using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP3.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên nhân viên bắt buộc nhập")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        // Navigation
        public ICollection<AccountingTransaction> AccountingTransactions { get; set; } = new List<AccountingTransaction>();
    }
}
