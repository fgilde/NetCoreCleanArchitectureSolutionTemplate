using System;
using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Application.Contracts;
using $ext_safeprojectname$.Application.Hubs;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseEnvironment(this IApplicationBuilder app, IWebHostEnvironment env)
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

            return app;
        }

        $if$ ($ext_addSignalR$ == True && $ext_addServiceBus$ == True)
        public static IApplicationBuilder UseServiceBusClientEventDelegation(this IApplicationBuilder app)
        {
            var tokenSource = new CancellationTokenSource();
            app.ApplicationServices.GetService<IServiceBus>().ListenAsync<ClientEvent>(Constants.ServiceBusQueues.ClientEventQueue, evt =>
            {
                app.ApplicationServices.GetService<IMediator>().Publish(evt.Clone(), tokenSource.Token);
            }, tokenSource.Token);
            return app;
        }
        $endif$

        $if$ ($ext_addSignalR$ == True)
        public static IApplicationBuilder UseSessionId(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var id = context.Session.GetString(Constants.SessionIdKey);
                if (string.IsNullOrEmpty(id))
                    context.Session.SetString(Constants.SessionIdKey, Guid.NewGuid().ToString());

                await next.Invoke();
            });
            return app;
        }
        $endif$
    }
}