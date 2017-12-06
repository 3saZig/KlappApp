using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using KlappAppen.Models.Entities;
using KlappAppen.Models;
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
            var connstring = @"Data Source=klappappenserver.database.windows.net;Initial Catalog=KlappAppen;Persist Security Info=True;User ID=klappappen;Password=polkagris3!";
            services.AddDbContext<KlappAppContext>(o => o.UseSqlServer(connstring));
            services.AddMvc();
            services.AddTransient<DBPersonsRepository>();
            //services.AddTransient<Person[]>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddReact();
            //return services.BuildServiceProvider();
            
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseMvcWithDefaultRoute();
            //app.UseReact(config =>
            //   { });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            
        }
    }
}
