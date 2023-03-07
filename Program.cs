using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MockCRM.Filters;
using MockCRM.Models;
using Pomelo.EntityFrameworkCore.MySql.IntegrationTests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//configure mysql
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<ApplicationDbContext>(
      dbContextOptions => dbContextOptions
          .UseMySql(builder.Configuration.GetConnectionString("default"), serverVersion)
          // The following three options help with debugging, but should
          // be changed or removed for production.
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors()
  );

//configure cors
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); 
}
app.UseCors(option => option.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                       );

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
