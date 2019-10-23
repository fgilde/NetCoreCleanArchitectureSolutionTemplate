using System;
using System.Threading;
using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.System;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace $safeprojectname$
{
    internal class SampleService : BackgroundService
    {
        private readonly IMediator mediator;
        public SampleService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var version = await this.mediator.Send(new GetVersion.Request(), stoppingToken);
            System.Console.WriteLine(@"-----------------------------------------------------------------------------------------");
            System.Console.WriteLine($@"Version: {version.Application}; {version.Runtime}; {version.System}");
            System.Console.WriteLine(@"-----------------------------------------------------------------------------------------");
            System.Console.WriteLine();
        }
    }
}
