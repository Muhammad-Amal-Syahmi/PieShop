using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Models;

namespace PieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // In this method, we will add services to the DI container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AWS_POSTGREQL_TRIALContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AWS_POSTGREQL_TRIALContext>();

            services.AddTransient<IPieRepository, PieRepository>(); // whenever someone asking for an IPieRepo, a new MockPieRepo will be returned
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage(); //if something go wrong, we will get an exception
            app.UseStatusCodePages(); //show status of request
            app.UseStaticFiles(); //return static class in wwwroot
            app.UseAuthentication(); //add support authentication
            app.UseMvc(routes =>
            {
                //here is just same as UseMvcWithDefaultRoute()
                // state that default controller= Home, default action = Index and Id is optional.
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

            });

            //app.UseMvcWithDefaultRoute(); //MVC middleware component

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
