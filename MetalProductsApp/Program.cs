using MetalProducts.DAL;
using MetalProducts.DAL.Interfaces;
using MetalProducts.DAL.Repositories;
using MetalProducts.Domain.Entity;
using MetalProducts.Domain.Response;
using MetalProducts.Service.Implementations;
using MetalProducts.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetalProductsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IBaseRepository<OrderEntity>, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            
            var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionStrings");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
     

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
                pattern: "{controller=Order}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
