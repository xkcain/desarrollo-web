using System;
using Admin_Login.Areas.Identity.Data;
using Admin_Login.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Admin_Login.Areas.Identity.IdentityHostingStartup))]
namespace Admin_Login.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LOGINCRUDContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Admin_LoginDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;

                })
                    .AddEntityFrameworkStores<LOGINCRUDContext>();
            });
        }
    }
}