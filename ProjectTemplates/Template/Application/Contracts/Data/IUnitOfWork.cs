using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using $ext_safeprojectname$.Domain.Entities;

namespace $safeprojectname$.Contracts.Data
{
    public interface IUnitOfWork
    {
        IUnitOfWorkScope Begin();
        IUnitOfWorkWriteScope BeginWrite();
    }

    public interface IUnitOfWorkScope : IDisposable
    {
        IRepository<MyEntity> Nodes { get; }
        IRepository<TEntity> EntitiesOf<TEntity>() where TEntity : EntityBase;
    }

    public interface IUnitOfWorkWriteScope : IUnitOfWorkScope
    {
        Task<int> CompleteAsync();
    }
}
