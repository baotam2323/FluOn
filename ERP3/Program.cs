using ERP3.Data;
using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// 1. Cấu hình DbContext
// ==========================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================
// 2. Cấu hình Identity
// ==========================
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// ==========================
// 3. Cấu hình Razor Pages + Runtime Compilation
// ==========================
builder.Services.AddControllersWithViews()
       .AddRazorRuntimeCompilation(); // cần gói Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation

builder.Services.AddRazorPages();

// ==========================
// 4. Đăng ký Services
// ==========================
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountingService, AccountingService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IAccountingTransactionService, AccountingTransactionService>();

// ==========================
// 5. Cấu hình app
// ==========================
var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

// Run app
app.Run();
