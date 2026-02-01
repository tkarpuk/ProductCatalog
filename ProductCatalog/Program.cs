using ProductCatalog.Data;
using ProductCatalog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// .AddSingleton() because I want to see result of operation like: Create, Delete etc.
// it's temporary until I change it by DbContext
builder.Services.AddSingleton<IRepository<Product>, InMemoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
