using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DIS_Project.Data;
using DIS_Project.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0)), // Specify your MySQL server version here
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()); // Enable retry on failure
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<CrashRecordsController>();


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

app.Run();
