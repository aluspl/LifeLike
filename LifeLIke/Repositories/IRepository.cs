using System.Collections.Generic;
using LifeLike.Models;

namespace LifeLike.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> List();
        T Get(long id);
        Result Update(T model);
        Result Delete(T model);
    }
}