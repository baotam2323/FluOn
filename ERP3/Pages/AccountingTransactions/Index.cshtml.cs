using ERP3.Data;
using ERP3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP3.Pages.AccountingTransactions
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<AccountingTransaction> Transactions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Transactions = await _context.AccountingTransactions
                                         .Include(t => t.Warehouse)
                                         .Include(t => t.Location)
                                         .Include(t => t.Employee) // nếu cần hiển thị tên nhân viên
                                         .AsNoTracking()
                                         .ToListAsync();
        }
    }
}
