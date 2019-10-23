using System;
using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Application.Contracts;
using $safeprojectname$.Serializer;

namespace $safeprojectname$
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResources(this IServiceCollection services)
        {
            services
                .AddTransient<IDateProvider, DateProvider>()
                .AddTransient<IJsonSerializer, JsonSerializer>();

            return services;
        }
    }
}
