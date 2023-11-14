using System.Diagnostics;
using LifeLike.Common.Enums;
using LifeLike.Common.Extensions;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Video;
using LifeLike.Services.Domain.Profiles;
using LifeLike.Services.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services.Page;

public class ContentService : BaseService, IContentService
{
    private readonly IRepository<ContentEntity> _repo;

    public ContentService(IRepository<ContentEntity> repo) : base()
    {
        _repo = repo;
    }

    public async Task<ContentModel> Create(ContentWriteModel model)
    {
        var item = new ContentEntity()
        {
            Category = model.Category,
            Content = model.Content,
            Name = model.Name,
            Url = model.Url,
        };
        item = await _repo.Add(item);
        return item.Map();
    }

    public async Task<IEnumerable<ContentModel>> List()
    {
        var items = await _repo.GetAll();
        Debug.WriteLine(items.ToJSON());
        return items.Select(x => x.Map()).ToList();
    }

    public async Task<IEnumerable<ContentModel>> ListByCategory(ContentCategory category)
    {
        var items = await _repo.Find(p => p.Category == category).ToListAsync();
        Debug.WriteLine(items.ToJSON());
        return items.Select(x => x.Map()).ToList();
    }

    public async Task<ContentModel> Get(Guid id)
    {
        var item = await _repo.Get(o => o.Id == id);
        return item.Map();
    }

    // Add Update logic
    public async Task<ContentModel> Update(Guid id, ContentWriteModel model)
    {
        var item = await _repo.Get(o => o.Id == id);
        item = await _repo.Update(item);
        return item.Map();
    }

    public async Task Delete(Guid id)
    {
        await _repo.Delete(o => o.Id == id);
    }
}