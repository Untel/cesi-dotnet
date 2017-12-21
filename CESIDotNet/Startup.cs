using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESICommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CESICommerce
{
    public class Startup
    {
        IConfiguration config;
        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddTransient<IProductRepository, FalseProductRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.config["ConnectionStrings:CESICommerceProducts"]));
            services.AddTransient<IProductRepository, EFProductRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseMvc(routes => {

                routes.MapRoute(
                    "Default",
                    "{page}",
                    new { controller = "Product", action = "List", page = 1 }
                );
                routes.MapRoute(
                    "Product",
                    "product/{id}",
                    new { controller = "Product", action = "Product", id = 1 }
                );
            });
            SeedData.Seed(app);
        }
    }
}
