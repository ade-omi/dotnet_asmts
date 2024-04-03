using Microsoft.EntityFrameworkCore;
using OMIYALE_TRUCKROUTE_LABS.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TR_DBContext>(opts => {
    opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:TRDBConnStr"]);
    });
builder.Services.AddScoped<ITruckRepository, TruckRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
