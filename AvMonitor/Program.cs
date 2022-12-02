using AvMonitor.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AvMonitor.Data;
using AvMonitor.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AvMonitorContextConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

connectionString = builder.Configuration.GetConnectionString("TaskDataConnection");
builder.Services.AddDbContext<TaskDataContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddTransient<DataBase>();

builder.WebHost.UseUrls("https://localhost:7012");

var app = builder.Build();

HttpManager.Init(@"https://localhost:7284");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();



app.MapGet("database/tasks", async (TaskDataContext db) => await db.Tasks.ToListAsync());
app.MapGet("database/responses", async (TaskDataContext db) => await db.Tasks.ToListAsync());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


