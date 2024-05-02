using Microsoft.AspNetCore.Identity;
using The_Medallion_Theater.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnString = builder.Configuration.GetConnectionString("MySQlConn");

builder.Services.AddScoped<IManageRepository, ManageRepository>(); 
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseMySql(ConnString, ServerVersion.AutoDetect(ConnString));
});

builder.Services.AddIdentity<Patron, IdentityRole>().
    AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Theater}/{action=Browse}/{id?}");

app.Run();
