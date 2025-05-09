using CarDealership.Data;
using CarDealership.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CarDealership.Models;

namespace CarDealership
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("CarDealershipConnection") ?? throw new InvalidOperationException("Connection string 'CarDealershipContextConnection' not found.");

            builder.Services.AddDbContext<CarDealershipContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CarDealershipContext>();

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddApplication(builder.Configuration);

            //builder.Services.AddControllersWithViews();

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

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });

            app.Run();
        }
    }
}
