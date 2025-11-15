using ERP5.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP5.Data
{
    public class Dbcontext : IdentityDbContext<ApplicationUser>
    {
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options) { }

        // Inventory & Orders
        public DbSet<Shipment> Shipments { get; set; }  // <-- thêm dòng này

        public DbSet<TokenLog> TokenLogs { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

        // Financial
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Payment> Payments { get; set; }

        // Invoice
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        // Warehouse
        public DbSet<WarehouseTransaction> WarehouseTransactions { get; set; }

        // Supplier
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Decimal precision
            modelBuilder.Entity<InventoryItem>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<PurchaseOrder>().Property(p => p.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<PurchaseOrderItem>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<SalesOrder>().Property(p => p.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<SalesOrderItem>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<InvoiceItem>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<FinancialTransaction>().Property(p => p.Amount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Payment>().Property(p => p.Amount).HasColumnType("decimal(18,2)");

            // Relationships can also be configured here if needed
        }
    }
}
