using System;
using Inventory.Areas.Identity.Data;
using Inventory.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Inventory.Areas.Identity.IdentityHostingStartup))]
namespace Inventory.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Default")));

                services.AddDefaultIdentity<Authentication>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                    })
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}