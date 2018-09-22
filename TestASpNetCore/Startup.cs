using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestASpNetCore.Data;
using TestASpNetCore.Model;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace TestASpNetCore
{
    public class Startup
    {
        IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeting, Greeting>();
            services.AddDbContext<SqlDBContext>(opt => opt.UseSqlServer(_config.GetConnectionString("RestaurantConn")));
            services.AddScoped<IRestaurant, SQLRestaurant>();
            services.AddMvc();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(option =>
            {
                _config.Bind("AzureAd", option);
            })
            .AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeting greet, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());
            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);
            //app.UseMvcWithDefaultRoute();
            app.UseAuthentication();

            app.UseMvc(ConfigureRoute);
            
           

            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path.StartsWithSegments("/mym"))
                    {
                        logger.LogInformation("Inside the request");
                        await context.Response.WriteAsync("Hit My Middle Ware");
                        logger.LogInformation("Request handled");
                    }
                    else
                    {
                        logger.LogInformation("Request forwarded");
                        await next(context);
                    }
                };

            });

            app.UseWelcomePage(new WelcomePageOptions
            {
                 Path = "/wp"
            }
            );

            //app.Run(async (context) =>
            //{

            //    string setting = greet.GetMessage();
            //    //await context.Response.WriteAsync($"{setting} : {env.EnvironmentName}");
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync($"Not Found");
            //});
        }

        public void ConfigureRoute(IRouteBuilder route)
        {
            route.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
