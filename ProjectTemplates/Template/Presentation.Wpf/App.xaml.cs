using System;
using Microsoft.Extensions.Configuration;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Persistence;
using $ext_safeprojectname$.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static ServiceProvider serviceProvider;
        private readonly IConfiguration configuration;

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddApplication();
            services.AddResources();
            services.AddPersistence(configuration.GetConnectionString("default"));
            serviceProvider = services.BuildServiceProvider();
        }
        public static T Get<T>()
        {
            return serviceProvider.GetService<T>();
        }
    }
}
