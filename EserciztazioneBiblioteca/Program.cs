using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EserciztazioneBiblioteca.Data;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EserciztazioneBibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EserciztazioneBibliotecaContext") ?? throw new InvalidOperationException("Connection string 'EserciztazioneBibliotecaContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Recources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
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

var supportedCultures = new[] { "en", "fr", "es","it" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

var cultureInfo = new CultureInfo("it-IT")
{
    NumberFormat =
                {
                    CurrencySymbol = "€",
                    NumberDecimalDigits = 2,
                    CurrencyDecimalDigits = 2,
                    CurrencyDecimalSeparator = ",",
                    CurrencyGroupSeparator = ".",
                    NumberDecimalSeparator = ","
                }
};
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();