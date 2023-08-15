using Microsoft.EntityFrameworkCore;
using MVCPrinciples.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<SettingsModel>(builder.Configuration.GetSection("MySettings"));
builder.Services.AddDbContext<MvcprinciplesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("MySettings:ConnectionString"));
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
