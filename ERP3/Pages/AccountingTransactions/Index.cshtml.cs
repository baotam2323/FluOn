using ERP3.Data;
using ERP3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Pages.AccountingTransactions
{
    // 🔒 Chỉ Admin và Accountant được xem trang này
    [Authorize(Roles = "Admin,Accountant")]
    public class IndexModel : PageModel
    {
        private readonly Data.AppDbContext _context;

        public IndexModel(Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<AccountingTransaction> Transactions { get; set; } = new List<AccountingTransaction>();

        public async Task OnGetAsync()
        {
            Transactions = await _context.AccountingTransactions
                                         .Include(t => t.Warehouse)
                                         .Include(t => t.Location)
                                         .Include(t => t.Employee)
                                         .AsNoTracking()
                                         .ToListAsync();
        }
    }
}
