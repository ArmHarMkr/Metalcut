using MetalcutWeb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using MetalcutWeb.Domain.Roles;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.DAL.Implementations;
using MetalcutWeb.Service.Interface;
using MetalcutWeb.Service.Implementation;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddDefaultIdentity<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        builder.Services.AddScoped<IChatRepository, ChatRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.MapRazorPages();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        app.MapAreaControllerRoute(
            name: "admin_area",
            areaName: "Admin",
            pattern: "admin/{controller=Home}/{action=Index}/{id?}"
        );

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { SD.Role_Employee, SD.Role_Customer, SD.Role_Manager, SD.Role_Admin };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            string email = "admin@admin.com";
            if (await userManager.FindByEmailAsync(email) != null)
            {
                var user = await userManager.FindByEmailAsync(email);
                await userManager.AddToRoleAsync(user, SD.Role_Admin);
            }
        }


        app.Run();
    }
}