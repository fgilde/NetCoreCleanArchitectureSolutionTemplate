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
            public int Id { get; set; }
        }

        internal class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                using var _scope = this.unitOfWork.BeginWrite();
                _scope.Nodes.Delete(request.Id);
                await _scope.CompleteAsync();
                return Unit.Value;
            }
        }

        internal class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }
    }
}
