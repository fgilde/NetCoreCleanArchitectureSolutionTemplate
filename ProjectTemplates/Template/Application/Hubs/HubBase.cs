using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using $safeprojectname$.Contracts;

namespace $safeprojectname$.Hubs
{
    public abstract class HubBase : Hub
    {
        private readonly ISessionProvider sessionProvider;

        protected HubBase(ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, sessionProvider.SessionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, sessionProvider.SessionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}