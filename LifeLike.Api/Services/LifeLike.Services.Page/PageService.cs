using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Domain.Profiles;

namespace LifeLike.Services.Page;

public class PageService : QueryPageService, IPageService
{
    private readonly ILinkService _linkService;

    public PageService(
        IRepository<PageEntity> repository,
        ILinkService linkService)
        : base(repository)
    {
        _linkService = linkService;
    }

    public async Task<PageModel> Create(CreatePageModel model)
    {
        await ValidateShortname(model);
        var item = PageEntity.New(model.ShortName, model.FullName);

        item = await _repository.Add(item);
        return item.Map();
    }

    // Create Correct Update Logic
    public async Task<PageModel> Update(Guid id, CreatePageModel model)
    {
        var item = await GetEntity(p => p.Id == id);
        item = await _repository.Update(item);
        return item.Map();
    }

    public async Task Delete(Guid id)
    {
        var model = await GetEntity(p => p.Id == id);
        if (model.LinkId.HasValue)
        {
            await _linkService.Delete(model.LinkId.Value);
        }

        await _repository.Delete(query => query.Id == model.Id);
    }

    private async Task ValidateShortname(CreatePageModel model)
    {
        if (await _repository.Any(p => p.Shortname == model.ShortName))
        {
            model.ShortName = $"{model.ShortName}+ 1";
        }
    }
}