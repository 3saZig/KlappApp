using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using KlappAppen.Models;
using KlappAppen.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using React.AspNet;

namespace KlappAppen
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var connstring = @"Data Source=.;Initial Catalog=KlappApp;Integrated Security=True;Pooling=False";
            //var connstring = @"Data Source=klappappenserver.database.windows.net;Initial Catalog=KlappAppen;Persist Security Info=True;User ID=klappappen;Password=polkagris3!";
            var connstring = @"Data Source=klappappenserver.database.windows.net;Initial Catalog=KlappAppen;Integrated Security=False;User ID=klappappen;Password=polkagris3!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            services.AddDbContext<KlappAppContext>(o => o.UseSqlServer(connstring));

            services.AddDbContext<IdentityDbContext>(o => o.UseSqlServer(connstring));

            services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<DBBudgetRepository>();

            services.AddAuthentication
                (CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = "/Account/Login");


            services.AddMvc();
            //services.AddTransient<Person[]>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddReact();
            //return services.BuildServiceProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /* -----------
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            //app.UseMvcWithDefaultRoute();
            //app.UseReact(config =>
            //   { });
            app.UseAuthentication();
            //För login 

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});
            -------------- */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
