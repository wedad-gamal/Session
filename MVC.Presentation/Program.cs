using Microsoft.AspNetCore.Identity;
using MVC.Presentation.Middlewares;

namespace MVC.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services//.AddRazorRuntimeCompilation()
            .AddControllersWithViews();
        //        builder.Services.ToJson(Newtonsoft.Json.Formatting.None);


        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseLazyLoadingProxies();
        });

        builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
        builder.Services.AddTransient<IEmailService, EmailService>();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //.AddCookie(options =>
        //{
        //    options.LoginPath = "/Account/Login";
        //    options.AccessDeniedPath = "/Account/AccessDenied";
        //});


        //var configuration = builder.Configuration;
        //builder.Services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})
        //.AddJwtBearer(options =>
        //{
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = configuration["Jwt:Issuer"],
        //        ValidAudience = configuration["Jwt:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(
        //            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        //    };
        //});



        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IGenereicRepository<Country>, GenereicRepository<Country>>();
        builder.Services.AddScoped<IGenereicRepository<City>, GenereicRepository<City>>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<DepartmentListResolver>();
        builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();

        builder.Services.AddScoped<Func<Type, object>>(provider =>
        {
            return type => provider.GetRequiredService(type);
        });

        Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Enrich.WithThreadId()
                    .Enrich.WithEnvironmentUserName()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .Enrich.FromLogContext()
                    .Enrich.WithCorrelationIdHeader("X-Correlation-ID") // or your preferred header
                    .WriteTo.File("Logs/hrsystem-log-.txt", rollingInterval: RollingInterval.Day,
                        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] ({CorrelationId}) {Message:lj}{NewLine}{Exception}")
                    .WriteTo.Seq("http://localhost:5341") // seq

                    .CreateLogger();

        builder.Host.UseSerilog();

        var app = builder.Build();

        app.UseMiddleware<CorrelationIdMiddleware>();
        app.UseMiddleware<RequestResponseLoggingMiddleware>();
        //app.UseMiddleware<ResponseLoggingMiddleware>();
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
