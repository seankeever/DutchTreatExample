using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //MvcOptions mvcOptions = new MvcOptions();
            //mvcOptions.EnableEndpointRouting = false;
        }




        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseDefaultFiles();   //this was for when I was serving index.html now I am using mvc instead so comment this out

            if(env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //TODO: add error page
            }

            app.UseStaticFiles();
            
            app.UseNodeModules();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Fallback",
                   "{controller}/{action}/{id?}",
                   new { controller = "App", action = "Index" });
            });

            //app.UseMvc(cfg =>
            //{
            //    cfg.MapRoute("Default",
            //       "{controller}/{action}/{id?}",
            //       new { controller = "App", action = "Index" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{

        //    //if (env.IsDevelopment())
        //    //{
        //    //    app.UseDeveloperExceptionPage();
        //    //}

        //    //app.UseRouting();

        //    //app.UseEndpoints(endpoints =>
        //    //{
        //    //    endpoints.MapGet("/", async context =>
        //    //    {
        //    //        await context.Response.WriteAsync("Hello World!");
        //    //    });
        //    //});



        //    //app.Run(async context=>
        //    //{
        //    //    await context.Response.WriteAsync("Hello World!");
        //    //});
        //}
    }
}
