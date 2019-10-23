using System.Threading.Tasks;
using $ext_safeprojectname$.Application.Contracts.Data;
using $ext_safeprojectname$.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        IUnitOfWorkScope IUnitOfWork.Begin() => new UnitOfWorkScope(this.context);
        IUnitOfWorkWriteScope IUnitOfWork.BeginWrite() => new UnitOfWorkWriteScope(this.context);

        private class UnitOfWorkScope : IUnitOfWorkScope
        {
            protected readonly DataContext context;
            public IRepository<MyEntity> Nodes => new Repository<MyEntity>(this.context);
            
            public IRepository<TEntity> EntitiesOf<TEntity>() where TEntity : EntityBase
            {
                return new Repository<TEntity>(context);
            }

            public UnitOfWorkScope(DataContext context)
            {
                this.context = context;
                this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }

            public virtual void Dispose() { }
        }

        private class UnitOfWorkWriteScope : UnitOfWorkScope, IUnitOfWorkWriteScope
        {
            public UnitOfWorkWriteScope(DataContext context)
                : base(context)
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            }

            async Task<int> IUnitOfWorkWriteScope.CompleteAsync() => await context.SaveChangesAsync();
        }
    }
}
