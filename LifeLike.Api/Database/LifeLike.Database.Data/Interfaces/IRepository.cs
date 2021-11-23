using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LifeLike.Database.Data.Entities;

namespace LifeLike.Database.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindSlim(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAll();

        Task<T> Get(Expression<Func<T, bool>> predicate = null);

        Task<T> Add(T entity);

        Task<T> Delete(Expression<Func<T, bool>> predicate = null);

        Task<T> Delete(Guid id);

        Task<T> Update(T entity);

        Task<long> Count(Expression<Func<T, bool>> predicate);

        Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}
