namespace $safeprojectname$
{
    public class Constants
    {
        public const string ApplicationName = "$ext_safeprojectname$";
        public const string SessionIdKey = nameof(SessionIdKey);

        public static class Environment
        {
            public const string Testing = nameof(Testing);
            public const string Development = nameof(Development);
            public const string Production = nameof(Production);
        }

        public static class EventNames
        {
            public const string ClientEventName = "EventRecieved";
        }

        public static class ServiceBusQueues
        {
            public const string TestQueue = nameof(TestQueue);
            public const string ClientEventQueue = nameof(ClientEventQueue);
            public const string MainQueue = nameof(MainQueue);
        }
}
}
