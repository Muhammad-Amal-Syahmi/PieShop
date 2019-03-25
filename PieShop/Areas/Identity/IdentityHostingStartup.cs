using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Models;

[assembly: HostingStartup(typeof(PieShop.Areas.Identity.IdentityHostingStartup))]
namespace PieShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<AWS_POSTGREQL_TRIALContext>();
            });
        }
    }
}