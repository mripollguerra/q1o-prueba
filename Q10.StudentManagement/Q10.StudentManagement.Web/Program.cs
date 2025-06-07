using Q10.StudentManagement.Domain;
using Q10.StudentManagement.Infrastructure.EntityFramework;
using Q10.StudentManagement.Infrastructure.EntityFramework.Repositories;
using Q10.StudentManagement.Library.Cqrs;
using Q10.StudentManagement.Library.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddRepository<Q10Context>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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