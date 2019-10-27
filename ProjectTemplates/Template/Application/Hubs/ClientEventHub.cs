using $safeprojectname$.Contracts;

namespace $safeprojectname$.Hubs
{
    public class ClientEventHub : HubBase
    {
        public ClientEventHub(ISessionProvider sessionProvider) : base(sessionProvider)
        {}
    }
}
