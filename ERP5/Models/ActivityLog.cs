using System;

namespace ERP5.Models
{
    public class ActivityLog
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Page { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
