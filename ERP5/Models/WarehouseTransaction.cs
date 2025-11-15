namespace ERP5.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class WarehouseTransaction
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int InventoryItemId { get; set; }
    [ForeignKey("InventoryItemId")]
    public InventoryItem InventoryItem { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string Type { get; set; } // "IN" or "OUT"

    public string ProcessedById { get; set; }
    [ForeignKey("ProcessedById")]
    public ApplicationUser ProcessedBy { get; set; }

    public DateTime ProcessedAt { get; set; } = DateTime.Now;
}
