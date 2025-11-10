using ERP3.Data;
using ERP3.Models;
using ERP3.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// 1. Cấu hình DbContext
// ==========================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()  // Có thể bật để debug
           .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.AmbientTransactionWarning)) // Suppress warning nếu muốn
);

// ==========================
// 2. Cấu hình Identity
// ==========================
builder.Services.AddIdentity<User, IdentityRole>(options =>
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
// 3. Razor Pages + Runtime Compilation
// ==========================
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// ==========================
// 4. Session & Cookie
// ==========================
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ==========================
// 5. Đăng ký các Services
// ==========================
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountingService, AccountingService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IAccountingTransactionService, AccountingTransactionService>();

var app = builder.Build();

// ==========================
// Middleware
// ==========================
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

app.UseSession();

app.MapRazorPages();
app.MapControllers();

// ==========================
// 6. Tự động migrate & Seed Admin User/Role
// ==========================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Migrate database
    context.Database.Migrate();

    // Seed Role
    var adminRole = "Admin";
    if (!await roleManager.RoleExistsAsync(adminRole))
    {
        await roleManager.CreateAsync(new IdentityRole(adminRole));
    }

    // Seed Admin User
    var adminUserName = "admin";
    var adminEmail = "admin@example.com";
    var adminPassword = "123456"; // theo policy password đã cấu hình
    var adminUser = await userManager.FindByNameAsync(adminUserName);
    if (adminUser == null)
    {
        adminUser = new User
        {
            UserName = adminUserName,
            Email = adminEmail,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (!result.Succeeded)
            throw new Exception("Failed to create admin user: " + string.Join("; ", result.Errors.Select(e => e.Description)));
    }

    // Gán role Admin cho user
    if (!await userManager.IsInRoleAsync(adminUser, adminRole))
    {
        await userManager.AddToRoleAsync(adminUser, adminRole);
    }
}

app.Run();
