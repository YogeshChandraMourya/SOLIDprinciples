using Microsoft.EntityFrameworkCore;
using SOLIDDb_15_12_23_.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});


builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SolidContext>(options =>
    options.UseSqlServer("DefaultConnection"));
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddTransient<IEmailService, EmailService>();



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
