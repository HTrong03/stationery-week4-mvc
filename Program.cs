using Microsoft.EntityFrameworkCore;
using StationeryWeek3.Mvc.Data;
using StationeryWeek3.Mvc.Options;
using StationeryWeek3.Mvc.Services;
using StationeryWeek3.Mvc.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<
    IStationeryService,
    StationeryService>();

builder.Services.AddScoped<
    IStationeryRepository,
    StationeryRepository>();

builder.Services.AddScoped<
    IStockIssueRepository,
    StockIssueRepository>();

builder.Services.AddScoped<
    IStockIssueService,
    StockIssueService>();
    
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration
                .GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
