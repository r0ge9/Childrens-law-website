using Diplom.Domain;
using Diplom.Domain.Repositories.Abstract;
using Diplom.Domain.Repositories.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().SetCompatibilityVersion(version: CompatibilityVersion
    .Version_3_0).AddSessionStateTempDataProvider();
builder.Services.AddTransient<ITestRepository, EFTestRepository>();
builder.Services.AddTransient<IReviewRepository, EFReviewRepository>();
builder.Services.AddTransient<IEventRepository, EFEventRepository>();
builder.Services.AddTransient<DataManager>();

var connection = @"Server=(localdb)\mssqllocaldb;Database=Diplom;Trusted_Connection=True;";
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connection));

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
