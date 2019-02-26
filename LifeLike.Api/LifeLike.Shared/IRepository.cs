using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LifeLike.Shared
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetOverviewQuery(Expression<Func<T, bool>> predicate = null);

        T GetDetail(Expression<Func<T, bool>> predicate = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void DeleteAll();
    }
}