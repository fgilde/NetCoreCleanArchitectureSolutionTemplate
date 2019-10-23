using System;
using $ext_safeprojectname$.Application;
using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Application.Contracts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<DataContext>((sp, builder) =>
            {
                var environment = sp.GetService<IHostEnvironment>();
                if (environment.IsEnvironment(Constants.Environment.Testing))
                {
                    // builder.UseSqlite(connectionString);
                }
                else
                {
                    //builder.UseSqlServer(connectionString);
                    builder.UseInMemoryDatabase($"{Guid.NewGuid().ToString()}-{connectionString}");
                }

                builder.UseInMemoryDatabase($"{Guid.NewGuid().ToString()}-{connectionString}");
                builder.UseLoggerFactory(sp.GetService<ILoggerFactory>());
                builder.EnableSensitiveDataLogging();
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
