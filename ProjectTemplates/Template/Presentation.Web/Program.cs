using System;
using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.System;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

            using (var scope = host.Services.CreateScope())
                await scope.ServiceProvider.GetService<IMediator>().Send(new InitializeApplication.Request());

            host.Run();
        }
    }
}
