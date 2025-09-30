namespace ERP3.Models
{
    public class TaxReportDto
    {
        public string WarehouseName { get; set; } = string.Empty;

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal TaxableIncome { get; set; } // Thu nhập tính thuế

        public decimal TaxAmount { get; set; } // Số thuế phải nộp
    }
}
