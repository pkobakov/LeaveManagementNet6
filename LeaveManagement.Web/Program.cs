using LeaveManagement.Web.Configuration;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Repositories;
using LeaveManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Serilog;

namespace LeaveManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<Data.ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Data.ApplicationDbContext>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25, "no-reply@leavemanagement.com" ));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            builder.Services.AddAutoMapper(typeof(MapperConfig));

            builder.Host.UseSerilog((ctx, lc) => 
                  lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}