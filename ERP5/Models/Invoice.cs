namespace ERP5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Invoice
{
    [Key]
    public int Id { get; set; }

    public int SalesOrderId { get; set; }
    [ForeignKey("SalesOrderId")]
    public SalesOrder SalesOrder { get; set; }

    public string CreatedById { get; set; }
    [ForeignKey("CreatedById")]
    public ApplicationUser CreatedBy { get; set; }

    public DateTime InvoiceDate { get; set; } = DateTime.Now;

    public ICollection<InvoiceItem> Items { get; set; }
}

public class InvoiceItem
{
    [Key]
    public int Id { get; set; }

    public int InvoiceId { get; set; }
    [ForeignKey("InvoiceId")]
    public Invoice Invoice { get; set; }

    public int InventoryItemId { get; set; }
    [ForeignKey("InventoryItemId")]
    public InventoryItem InventoryItem { get; set; }

    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}
