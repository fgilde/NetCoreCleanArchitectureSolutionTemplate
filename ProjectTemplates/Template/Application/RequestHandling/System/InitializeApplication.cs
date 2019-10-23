using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace $safeprojectname$.RequestHandling.System
{
    public class InitializeApplication
    {
        public class Request : IRequest { }

        internal class Handler : IRequestHandler<Request>
        {
            public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                // Initialize the $safeprojectname$ here
                // ...
                return Unit.Task;
            }
        }
    }
}
