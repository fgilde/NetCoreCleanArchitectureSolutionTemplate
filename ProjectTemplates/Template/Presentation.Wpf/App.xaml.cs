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

        public App()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddApplication();
            services.AddResources();
            services.AddPersistence("connecionString");
            serviceProvider = services.BuildServiceProvider();
        }
        public static T Get<T>()
        {
            return serviceProvider.GetService<T>();
        }
    }
}
