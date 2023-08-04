using Microsoft.EntityFrameworkCore;
using PointOfSales;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Configure Database
builder.Services.AddDbContext<PosDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Default"), new MySqlServerVersion(new Version(11, 0, 2)));
});
builder.Services.AddControllersWithViews();


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
