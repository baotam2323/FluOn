namespace ERP3.Models
{
    public class WarehouseReportDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = string.Empty;

        public int TotalTransactions { get; set; }   // Số lượng giao dịch
        public decimal TotalAmount { get; set; }     // Tổng số tiền
    }
}

