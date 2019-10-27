using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using $safeprojectname$.Contracts;

namespace $safeprojectname$.Hubs
{
    public class ClientEventDispatcher : INotificationHandler<ClientEvent>
    {
        private readonly IHubContext<ClientEventHub> _hubContext;
        private readonly ISessionProvider sessionProvider;

        public ClientEventDispatcher(IHubContext<ClientEventHub> hubContext, ISessionProvider sessionProvider)
        {
            _hubContext = hubContext;
            this.sessionProvider = sessionProvider;
        }

        public Task Handle(ClientEvent clientEvent, CancellationToken cancellationToken)
        {
            var targetProxy = clientEvent.Target == TargetClient.Current
                ? _hubContext.Clients.Group(sessionProvider.SessionId)
                : _hubContext.Clients.All;

            return targetProxy.SendAsync(Constants.EventNames.ClientEventName, clientEvent, cancellationToken: cancellationToken);
        }
    }
}