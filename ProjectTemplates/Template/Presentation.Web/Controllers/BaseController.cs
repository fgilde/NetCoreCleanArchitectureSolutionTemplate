using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= Get<IMediator>();
        protected T Get<T> () => HttpContext.RequestServices.GetService<T>();
    }
}
