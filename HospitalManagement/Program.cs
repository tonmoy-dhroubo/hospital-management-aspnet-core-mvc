using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProductionConnection") ?? throw new InvalidOperationException("Connection string 'HospitalManagementContextConnection' not found.");

builder.Services.AddDbContext<HospitalManagementContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<HospitalAdminUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<HospitalManagementContext>();

builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings.
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    //Location for your Custom Access Denied Page
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

    //Location for your Custom Login Page
    options.LoginPath = "/login";

});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
    {
        options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "login");
        options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "register");

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
