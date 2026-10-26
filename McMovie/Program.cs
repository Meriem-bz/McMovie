
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using McMovie.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("McMovieContext")
    ?? throw new InvalidOperationException(
        "Connection string 'McMovieContext' not found.");

builder.Services.AddDbContext<McMovieContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Use English number formatting for form values.
var culture = CultureInfo.GetCultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture),
    SupportedCultures = new[] { culture },
    SupportedUICultures = new[] { culture }
};

app.UseRequestLocalization(localizationOptions);

// Add sample movie data to the database.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
