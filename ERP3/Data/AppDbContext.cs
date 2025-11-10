using ERP3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP3.Data
{
    public class AppDbContext : IdentityDbContext<Models.User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccountingTransaction> AccountingTransactions { get; set; } = null!;
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;  // <== Thêm dòng này
        public DbSet<Models.Transaction> Transactions { get; set; } = null!;


        public DbSet<Models.User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // mapping các entity khác...
        }
    }
}

