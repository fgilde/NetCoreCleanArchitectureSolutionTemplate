﻿using $safeprojectname$.Data;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Persistence;
using $ext_safeprojectname$.Resources;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Hosting;

namespace $safeprojectname$
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddResources();
            services.AddPersistence(this.configuration.GetConnectionString("default"));
    //SPA $ext_addSPA$
    //Blazor $ext_addBlazor$
            $if$ ($ext_addSPA$ == True)
            services.AddSpaStaticFiles(spa => { spa.RootPath = "<path to client build in production>"; });
            $endif$
            $if$ ($ext_addBlazor$ == True)
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            $endif$
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                $if$ ($ext_addBlazor$ == True)
                endpoints.MapBlazorHub();
                $endif$
                endpoints.MapFallbackToPage("/_Host");
            });
            
            $if$ ($ext_addSPA$ == True)
            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.Options.SourcePath = "../../Frontend";
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
            $endif$
        }
    }
}