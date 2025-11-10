using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP3.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        //Navigation properties

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<AccountingTransaction> AccountingTransactions { get; set; } = new List<AccountingTransaction>();
        public string Address { get; internal set; }
    }
}
