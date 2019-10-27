using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using $safeprojectname$.Contracts.Data;
using MediatR;

namespace $safeprojectname$.RequestHandling.MyEntity
{
    public class DeleteMyEntity
    {
        public class Request : IRequest
        {
            public int? Id { get; set; }
        }

        internal class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMediator mediator;

            public Handler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                this.unitOfWork = unitOfWork;
                this.mediator = mediator;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                using var _scope = this.unitOfWork.BeginWrite();
                if (request.Id.HasValue)
                    _scope.Nodes.Delete(request.Id.Value);
                else
                    _scope.Nodes.DeleteAll();

                await _scope.CompleteAsync();
                await mediator.Publish(new ClientEvent(TargetClient.Current, "Entity Deleted", request.Id), cancellationToken);

                return Unit.Value;
            }
        }

        internal class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
               // RuleFor(x => x.Id).NotEmpty();
            }
        }
    }
}
