using System;

namespace ERP5.Models
{
    public class TokenLog
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int Amount { get; set; }  // số token
        public string Type { get; set; } = string.Empty; // "Buy", "Reward", etc.
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
