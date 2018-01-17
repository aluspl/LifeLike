using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Models;

namespace LifeLike.Repositories
{
    public interface IRepository<T>
    {
        Task<Result> Create(T model);

        Task<IEnumerable<T>> List();
        Task<T> Get(long id);
        Task<Result> Update(T model);
        Task<Result> Delete(T model);
        
    }
}