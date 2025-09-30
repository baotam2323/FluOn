namespace ERP3.Models
{
    public class EmployeeReportDto
    {
        public string EmployeeName { get; set; } = string.Empty;
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
    }
}
