﻿using $safeprojectname$.Data;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Application.Contracts;
$if$ ($ext_addSignalR$ == True)using $ext_safeprojectname$.Application.Hubs;$endif$
using $ext_safeprojectname$.Persistence;
using $ext_safeprojectname$.Resources;
$if$ ($ext_addSPA$ == True)using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;$endif$
using $safeprojectname$.Extensions;

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
            $if$ ($ext_addSignalR$ == True)
            services.AddSession();
            services.AddHttpContextAccessor();
            services.RemoveAll<ISessionProvider>().AddTransient<ISessionProvider, SessionProvider>();
            $endif$
            services.AddResources();
            services.AddPersistence(this.configuration.GetConnectionString("default"));
            $if$ ($ext_addSPA$ == True)
            services.AddSpaStaticFiles(spa => { spa.RootPath = "<path to client build in production>"; });
            $endif$
            $if$ ($ext_addBlazor$ == True)
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            $endif$
            
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader()
                        .AllowAnyOrigin();
                }));

            $if$ ($ext_addSwagger$ == True)
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v0.1";
                    document.Info.Title = Constants.ApplicationName;
                    document.Info.Description = $"{Constants.ApplicationName} API Reference";
                };
            });
            $endif$


        services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEnvironment(env);
            $if$ ($ext_addSignalR$ == True)
            app.UseSession();
            app.UseSessionId();
            $endif$
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            $if$ ($ext_addSPA$ == True)app.UseSpaStaticFiles();$endif$
            app.UseRouting();
                
            $if$ ($ext_addSwagger$ == True)
            app.UseOpenApi();
            app.UseSwaggerUi3();
            $endif$

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                $if$ ($ext_addBlazor$ == True) endpoints.MapBlazorHub(); $endif$
                $if$ ($ext_addSignalR$ == True) endpoints.MapHub<ClientEventHub>("/eventHub"); $endif$
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
            $if$ ($ext_addSignalR$ == True && $ext_addServiceBus$ == True)
            app.UseServiceBusClientEventDelegation();
            $endif$
        }
    }
}
