using System;

namespace $safeprojectname$.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message, params object[] args)
            : base(string.Format(message, args)) { }
    }
}
