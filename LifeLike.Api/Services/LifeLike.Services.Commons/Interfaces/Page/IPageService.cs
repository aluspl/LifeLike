using LifeLike.Services.Commons.Models.Page;

namespace LifeLike.Services.Commons.Interfaces.Page;

public interface IPageService : IQueryPageService
{
    Task<PageModel> Create(CreatePageModel model);

    Task Delete(Guid id);

    Task<PageModel> Update(Guid id, CreatePageModel model);
}