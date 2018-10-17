using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LifeLike.Data.Models.Enums;

namespace LifeLike.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetOverviewQuery(Expression<Func<T, bool>> predicate);

        T GetDetail(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void DeleteAll();
    }
}