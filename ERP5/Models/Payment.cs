namespace ERP5.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
    [Key]
    public int Id { get; set; }

    public int InvoiceId { get; set; }
    [ForeignKey("InvoiceId")]
    public Invoice Invoice { get; set; }

    [Required]
    public string PaidById { get; set; }
    [ForeignKey("PaidById")]
    public ApplicationUser PaidBy { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime PaidAt { get; set; } = DateTime.Now;

    [MaxLength(50)]
    public string PaymentMethod { get; set; } // e.g., "Cash", "Card", "Token"
}
