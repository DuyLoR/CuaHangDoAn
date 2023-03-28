using CuaHangDoAn.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Load env
Env.Load();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// Connection
var connectionString = builder.Configuration.GetConnectionString("CSEWebsiteContext");
connectionString = connectionString.Replace("$DATABASE_SERVER", Environment.GetEnvironmentVariable("DATABASE_SERVER"));
connectionString = connectionString.Replace("$DATABASE_PORT", Environment.GetEnvironmentVariable("DATABASE_PORT"));
connectionString = connectionString.Replace("$DATABASE_NAME", Environment.GetEnvironmentVariable("DATABASE_NAME"));
connectionString = connectionString.Replace("$DATABASE_USER", Environment.GetEnvironmentVariable("DATABASE_USER"));
connectionString = connectionString.Replace("$DATABASE_PASSWORD", Environment.GetEnvironmentVariable("DATABASE_PASSWORD"));
builder.Services.AddDbContext<CuaHangDoAnContext>(options => options.UseMySQL(connectionString));

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
