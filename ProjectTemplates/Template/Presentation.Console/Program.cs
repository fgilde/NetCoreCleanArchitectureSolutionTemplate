using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Application.RequestHandling.System;
using $ext_safeprojectname$.Resources;
using $ext_safeprojectname$.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace $safeprojectname$
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .UseConsoleLifetime()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices(ConfigureServices)
                .Build();

            using (var scope = host.Services.CreateScope())
                scope.ServiceProvider.GetService<IMediator>().Send(new InitializeApplication.Request()).Wait();

            await host.RunAsync();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder config)
        {
            config.SetBasePath(Environment.CurrentDirectory);
            config.AddJsonFile("appsettings.json", false);
            config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true);
            config.AddEnvironmentVariables();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddTransient<IWebHostEnvironment>(sp => new WebHostingEnvironment
            {
                EnvironmentName = Environments.Development,
                ContentRootPath = Environment.CurrentDirectory,
                WebRootPath = Environment.CurrentDirectory
            });

            services.AddTransient(sp => context.Configuration);
            services.AddLogging();
            
            services.AddApplication();
            services.AddResources();
            services.AddPersistence("connecionString");

            services.AddHostedService<SampleService>();
        }
    }

    class WebHostingEnvironment : HostingEnvironment, IWebHostEnvironment
    {
        public IFileProvider WebRootFileProvider { get; set; }
        public string WebRootPath { get; set; }
    }

}
