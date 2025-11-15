using System.ComponentModel.DataAnnotations;

namespace ERP5.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SupplierName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
