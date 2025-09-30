using System;

namespace ERP3.Models
{
    public class WarehouseReportItem
    {
        public string WarehouseName { get; set; } = string.Empty;
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance => TotalIncome - TotalExpense;
    }
}
