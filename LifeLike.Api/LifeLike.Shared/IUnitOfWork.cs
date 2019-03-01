using LifeLike.Shared.Enums;

namespace LifeLike.Shared
{
    public interface IUnitOfWork
    {
        IRepository<T> Get<T>()  where T : class;
        Result Save();
    }
}