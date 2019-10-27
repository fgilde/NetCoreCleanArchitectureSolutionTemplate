using System;

namespace $safeprojectname$.Contracts
{
    public interface ISessionProvider
    {
        string SessionId { get; }
    }

    public class SimpleSessionProvider : ISessionProvider
    {
        public SimpleSessionProvider()
        {
            SessionId = Guid.NewGuid().ToString();
        }

        public string SessionId { get; }
    }
}
