using Diplom.Domain;
using Diplom.Domain.Repositories.Abstract;
using Diplom.Domain.Repositories.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Globalization;
using System.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews().SetCompatibilityVersion(version: CompatibilityVersion
    .Version_3_0).AddSessionStateTempDataProvider();

builder.Services.AddTransient<ITestRepository, EFTestRepository>();
builder.Services.AddTransient<IReviewRepository, EFReviewRepository>();
builder.Services.AddTransient<IEventRepository, EFEventRepository>();
builder.Services.AddTransient<IQuestionRepository, EFQuestionRepository>();
builder.Services.AddTransient<DataManager>();

var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Diplom;AttachDbFilename=|DataDirectory|\\Data\\Diplom.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connection));
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews().
    AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).
	AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
        {
        new CultureInfo("en"),
        new CultureInfo("ru")
        };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ru");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures= supportedCultures;
});
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization();
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

using(var scope = app.Services.CreateScope())
{
    var services =scope.ServiceProvider;
    var localizationOptions = services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
    app.UseRequestLocalization(localizationOptions);
}

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
