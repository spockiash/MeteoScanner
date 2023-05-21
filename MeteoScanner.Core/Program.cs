using System.Configuration;
using Microsoft.EntityFrameworkCore;
using MScanner.Data;
using MScanner.Models.RequestModels;
using MScanner.Repository.RequestPresets;

var builder = WebApplication.CreateBuilder(args);
// Add configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MeteoScannerContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRequestPresetRepository<OpenAqRequestModel>, OpenAqRequestPresetRepository>();
var debug = configuration.GetConnectionString("DefaultConnection");


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
