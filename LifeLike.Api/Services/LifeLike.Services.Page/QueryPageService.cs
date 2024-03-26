using System.Linq.Expressions;
using LifeLike.Common.Exceptions;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Domain.Profiles;
using LifeLike.Services.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services.Page;

public class QueryPageService : BaseService, IQueryPageService
{
    protected readonly IRepository<PageEntity> _repository;

    public QueryPageService(
        IRepository<PageEntity> repository)
        : base()
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PageModel>> List()
    {
        var items = await _repository.GetAll();
        return items.Select(x => x.Map());
    }

    public async Task<PageModel> Get(Guid id)
    {
        var item = await _repository.Get(p => p.LinkId == id);
        return item.Map();
    }

    public async Task<PageModel> Get(string shortName)
    {
        var item = await GetEntity(p => p.Shortname == shortName);
        return item.Map();
    }

    public async Task<IEnumerable<PageModel>> ListByCategory(Guid categoryId)
    {
        var items = await _repository
            .Find(p => p.Categories.Any(entity => entity.Id == categoryId))
            .ToListAsync();
        return items.Select(x => x.Map());
    }

    protected async Task<PageEntity> GetEntity(Expression<Func<PageEntity, bool>> predicate)
    {
        return await _repository.Get(predicate)  ?? throw new NotFoundException($"Page not found");
    }
}