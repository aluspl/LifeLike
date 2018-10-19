using LifeLike.Data;
using LifeLike.Data.Models.Enums;

namespace LifeLike.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> Get<T>()  where T : class;
        Result Save();

    }
}