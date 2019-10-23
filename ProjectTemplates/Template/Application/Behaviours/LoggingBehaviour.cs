using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using $safeprojectname$.Contracts;

namespace $safeprojectname$.Behaviours
{
    internal class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private const int secondsBeforeLogWarning = 1;
        private readonly ILogger<TRequest> logger;
        private readonly IJsonSerializer serializer;

        public LoggingBehaviour(ILogger<TRequest> logger, IJsonSerializer serializer)
        {
            this.logger = logger;
            this.serializer = serializer;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (this.logger.BeginScope($"{typeof(TRequest).Name}_{Guid.NewGuid()}"))
            {
                this.logger.LogInformation($"Started with: {this.serializer.Serialize(request)}");

                var watch = Stopwatch.StartNew();
                var response = await next();
                watch.Stop();

                var logLevel = watch.Elapsed > TimeSpan.FromSeconds(secondsBeforeLogWarning) ? LogLevel.Warning : LogLevel.Information;
                this.logger.Log(logLevel, $"Done ({TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds):g})");

                return response;
            }
        }
    }
}
