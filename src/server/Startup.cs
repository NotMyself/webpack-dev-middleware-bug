using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // In production, the Vue files will be served
            //  from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = Configuration["Client"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //set up default mvc routing for api
            app.UseMvc(routes =>
            {
              routes.MapRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
            });

            //setup spa routing for both dev and prod
      if (env.IsDevelopment())
      {
        app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
            HotModuleReplacement = true,
            ProjectPath = Path.Combine(env.ContentRootPath, Configuration["ClientProjectPath"]),
            ConfigFile = Path.Combine(env.ContentRootPath, Configuration["ClientProjectConfigPath"])
        });
      }
      else
      {
        app.UseWhen(context => !context.Request.Path.Value.StartsWith("/api"),
          builder => {
            app.UseSpaStaticFiles();
            app.UseSpa(spa => {
              spa.Options.DefaultPage = "/index.html";
            });

            app.UseMvc(routes => {
              routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Fallback", action = "Index" });
            });
          });

      }

        }
    }
}
