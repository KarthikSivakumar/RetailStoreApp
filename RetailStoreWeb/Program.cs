using Microsoft.EntityFrameworkCore;
using RetailStoreWeb.Data;
using RetailStoreWeb.Services;
using RetailStoreWeb.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProductRepository,ProductService>(_=>new ProductService(new RetailStoreDBContext(builder.Configuration)));
builder.Services.AddTransient<IStoreRepository,StoreService>(_=>new StoreService(new RetailStoreDBContext(builder.Configuration)));
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options=>
options.AddPolicy(
    "CorsPolicy",
    builder=>builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
