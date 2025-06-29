

namespace MVCWebApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews(); //mvc
                                                    //builder.Services.AddControllers();//api
                                                    //builder.Services.AddRazorPages(); //razor pages
                                                    //builder.Services.AddMvc(); //mvc
                                                    //builder.Services.AddMvcCore(); //mvc core




        var app = builder.Build();
        app.UseStaticFiles(); // Enable static files (wwwroot)
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseEndpoints(endPoints =>
        {
            endPoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        });

        app.Run();
    }
}
