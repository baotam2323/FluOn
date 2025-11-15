using ERP5.Data;
using ERP5.Models;
using ERP5.Services;
using ERP5.Services.Implementations;
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// =========================
// --- Database Configuration ---
// =========================
builder.Services.AddDbContext<Dbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// =========================
// --- Identity Configuration ---
// =========================
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<Dbcontext>()
.AddDefaultTokenProviders();

// =========================
// --- Register ERP5 Services ---
// =========================
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();
builder.Services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();
builder.Services.AddScoped<IUserTokenService, UserTokenService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();


// =========================
// --- Razor Pages Configuration ---
// =========================
builder.Services.AddRazorPages(options =>
{
    // Chỉ Admin mới vào được folder /Admin
    options.Conventions.AuthorizeFolder("/Admin", "AdminPolicy");
});

// =========================
// --- Authorization Policies ---
// =========================
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("EmployeePolicy", policy => policy.RequireRole("Employee"));
    options.AddPolicy("CustomerPolicy", policy => policy.RequireRole("Customer"));
});

// =========================
// --- Build App ---
// =========================
var app = builder.Build();

// =========================
// --- Middleware ---
// =========================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// =========================
// --- Map Razor Pages ---
// =========================
app.MapRazorPages();

// =========================
// --- Run App ---
// =========================
app.Run();
