
using Lab3_WorkshopRSVP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core with SQLite
var databasePath = Path.Combine(
    builder.Environment.ContentRootPath,
    "workshoprsvp.db");

if (!builder.Environment.IsDevelopment())
{
    var dataDirectory = Environment.GetEnvironmentVariable("HOME");

    if (!string.IsNullOrEmpty(dataDirectory))
    {
        databasePath = Path.Combine(
            dataDirectory,
            "workshoprsvp.db");
    }
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={databasePath}"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Create the database and seed initial data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    context.Database.Migrate();

    DbInitializer.Seed(context);
}

app.Run();

