using Microsoft.EntityFrameworkCore;
using MVC.BLL.Repositories;
using MVC.DAL.Context;
using MVC.DAL.Entities;
using System.Reflection;

namespace MVC.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseLazyLoadingProxies();
        });
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IGenereicRepository<Employee>, GenereicRepository<Employee>>();
        builder.Services.AddScoped<IGenereicRepository<Country>, GenereicRepository<Country>>();
        builder.Services.AddScoped<IGenereicRepository<City>, GenereicRepository<City>>();

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
    }
}
