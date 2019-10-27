using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using $ext_safeprojectname$.Application.Contracts.Data;
using $ext_safeprojectname$.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$
{
    internal class Repository<T> : IRepository<T>
		where T : class
	{
		private readonly DataContext context;
		private readonly IQueryable<T> queryable;

		internal Repository(DataContext context)
		{
			this.context = context;
			this.queryable = this.context.Set<T>().AsQueryable().AsNoTracking();
		}
		
		Lazy<int> IRepository<T>.Insert(T entity)
		{
			var entry = this.context.Attach(entity);
			return new Lazy<int>(() =>
			{
				if (entry.State != EntityState.Unchanged)
					throw new InvalidOperationException("Access to Primarykey not possible before entity is saved (Scope must be completed)");

				return entry.CurrentValues.GetValue<int>("Id");
			});
		}

		void IRepository<T>.Update(int id, object values)
		{
			var existingEntity = this.context.Find<T>(id);
			if (existingEntity == null)
				throw Errors.NotFound(id, typeof(T).Name);

			this.context.Entry(existingEntity).CurrentValues.SetValues(values);
		}

		void IRepository<T>.Delete(T entity)
		{
			context.Remove(entity);
		}

        void IRepository<T>.Delete(int id)
        {
            context.Remove(context.Find<T>(id));
        }

        void IRepository<T>.DeleteAll()
        {
            context.RemoveRange(queryable);
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator() => this.queryable.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => this.queryable.GetEnumerator();

		Type IQueryable.ElementType => this.queryable.ElementType;

		Expression IQueryable.Expression => this.queryable.Expression;

		IQueryProvider IQueryable.Provider => this.queryable.Provider;
	}
}
