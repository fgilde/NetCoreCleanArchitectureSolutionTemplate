using System;
using Microsoft.AspNetCore.Http;
using $ext_safeprojectname$.Application;
using $ext_safeprojectname$.Application.Contracts;

namespace $ext_safeprojectname$.Presentation.Web
{
    public class SessionProvider : ISessionProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            SessionId = httpContextAccessor?.HttpContext?.Session.GetString(Constants.SessionIdKey) ?? Guid.NewGuid().ToString();
        }
        
        public string SessionId { get; set; }
    }
}