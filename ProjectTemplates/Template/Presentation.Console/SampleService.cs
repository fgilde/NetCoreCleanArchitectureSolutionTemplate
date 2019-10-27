using System;
using System.Threading;
using System.Threading.Tasks;
using $ext_safeprojectname$.Application.RequestHandling.System;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Hosting;
using $ext_safeprojectname$.Application.Contracts;
using $ext_safeprojectname$.Domain.Entities;

namespace $safeprojectname$
{
    internal class SampleService : BackgroundService
    {
        private readonly IMediator mediator;
        $if$ ($ext_addServiceBus$ == True)private readonly IServiceBus serviceBus;$endif$

        public SampleService(IMediator mediator $if$ ($ext_addServiceBus$ == True), IServiceBus serviceBus $endif$)
        {
            this.mediator = mediator;
            $if$ ($ext_addServiceBus$ == True) this.serviceBus = serviceBus; $endif$
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var version = await this.mediator.Send(new GetVersion.Request(), stoppingToken);
            Out("Version", version);
            $if$ ($ext_addServiceBus$ == True) 
            serviceBus.ListenAsync<MyEntity>("testqueue", entity =>
            {
                Out("Received on ServiceBus", entity);
            }, stoppingToken);
            $endif$
        }

        private void Out(string label, object obj)
        {
            string content = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Select((info, i) => $"{info.Name} : {info.GetValue(obj)}").Join(" ");
            System.Console.WriteLine(@"-----------------------------------------------------------------------------------------");
            System.Console.WriteLine($@"{label}: {content}");
            System.Console.WriteLine(@"-----------------------------------------------------------------------------------------");
            System.Console.WriteLine();
        }
    }
}
