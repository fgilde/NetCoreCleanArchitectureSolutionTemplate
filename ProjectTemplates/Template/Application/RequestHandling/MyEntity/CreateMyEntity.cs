using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Contracts.Data;
using MediatR;

namespace $safeprojectname$.RequestHandling.MyEntity
{
    public class CreateMyEntity
    {
        public class Request : IRequest<Domain.Entities.MyEntity>
        {}

        internal class Handler : IRequestHandler<Request, Domain.Entities.MyEntity>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Domain.Entities.MyEntity> Handle(Request request, CancellationToken cancellationToken)
            {
                using var scope = this.unitOfWork.BeginWrite();
                var r = scope.EntitiesOf<Domain.Entities.MyEntity>().Insert(new Domain.Entities.MyEntity());
                await scope.CompleteAsync();
                var result = scope.EntitiesOf<Domain.Entities.MyEntity>().FirstOrDefault(entity => entity.Id == r.Value);
                await mediator.Publish(new ClientEvent(TargetClient.Current, "Entity Created", result), cancellationToken);
                return result;
            }
        }

    }
}
