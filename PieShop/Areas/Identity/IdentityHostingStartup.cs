using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PieShop.DataAccess;
using PieShop.DataAccess.Auth;

[assembly: HostingStartup(typeof(PieShop.Areas.Identity.IdentityHostingStartup))]
namespace PieShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.User.RequireUniqueEmail = true;

                })
                .AddEntityFrameworkStores<AWS_POSTGREQL_TRIALContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
            });
        }
    }
}