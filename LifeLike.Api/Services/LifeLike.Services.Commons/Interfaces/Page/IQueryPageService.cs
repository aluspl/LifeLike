using LifeLike.Services.Commons.Models.Page;

namespace LifeLike.Services.Commons.Interfaces.Page;

public interface IQueryPageService
{
    Task<IEnumerable<PageModel>> ListByCategory(Guid categoryId);

    Task<PageModel> Get(Guid id);

    Task<PageModel> Get(string shortName);

    Task<IEnumerable<PageModel>> List();
}