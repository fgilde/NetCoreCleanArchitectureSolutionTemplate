using System;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Application.Contracts;
using $ext_safeprojectname$.Persistence;
using $ext_safeprojectname$.Resources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using EnvironmentName = Microsoft.Extensions.Hosting.EnvironmentName;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace $safeprojectname$.TestHelper
{
    public abstract class ApplicationTest
    {
        private static readonly IServiceCollection baseServices;
        private readonly IServiceProvider serviceProvider;

        protected TService Get<TService>() => this.serviceProvider.GetService<TService>();
        protected IMediator Mediator => this.Get<IMediator>();

        static ApplicationTest()
        {
            var testConfiguration = new ConfigurationBuilder().Build();

            baseServices = new ServiceCollection();
            baseServices.AddTransient<IWebHostEnvironment>(sp => new WebHostingEnvironment
            {
                EnvironmentName = Environments.Development,
                ContentRootPath = Environment.CurrentDirectory,
                WebRootPath = Environment.CurrentDirectory
            });

            baseServices.AddTransient<IConfiguration>(sp => testConfiguration);
            baseServices.AddLogging();
            
            baseServices.AddApplication();
            baseServices.AddResources();
            baseServices.AddPersistence("connecionString");

            baseServices.Replace(ServiceDescriptor.Transient(typeof(IDateProvider), sp => new TestOverrides.DateProvider()));
        }

        protected ApplicationTest()
        {
            var serviceCollection = new ServiceCollection().Add(baseServices);
            // Mutate services for Tests here (Fake, Mock)
            this.serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }

    class WebHostingEnvironment : HostingEnvironment, IWebHostEnvironment
    {
        public IFileProvider WebRootFileProvider { get; set; }
        public string WebRootPath { get; set; }
    }

}
