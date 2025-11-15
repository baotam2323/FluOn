namespace ERP5.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class UserToken
{
    internal DateTime createdAt;

    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public DateTime PurchasedAt { get; set; } = DateTime.Now;
    public DateTime CreatedAt { get; internal set; }
}

