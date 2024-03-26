using LifeLike.Common.Enums;
using LifeLike.Database.Data.Entities.Link;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Link;
using LifeLike.Services.Domain.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LifeLike.Services.Domain.Services;

public class LinkService : BaseService, ILinkService
{
    private readonly IRepository<LinkEntity> _linkRepository;
    private ILogger<LinkService> _logger;

    public LinkService(IRepository<LinkEntity> linkRepository, ILogger<LinkService> logger)
        : base()
    {
        _linkRepository = linkRepository;
        _logger = logger;
    }

    public async Task<LinkModel> Create(CreateLinkModel model)
    {
        var item = new LinkEntity()
        {
            Action = model.Action,
            Category = model.Category,
            Name = model.Name,
            Url = model.Url,
            Controller = model.Controller,
            IsExternal = model.IsExternal,
            IconName = model.IconName,
            Order = model.Order,
        };
        
        await _linkRepository.Add(item);
        return item.Map();
    }

    public async Task<IEnumerable<LinkModel>> List()
    {
        var items = await _linkRepository.GetAll();
        return items.Select(x => x.Map());
    }

    public async Task<IEnumerable<LinkModel>> List(LinkCategory category)
    {
        var list = await _linkRepository.Find(q => q.Category == category).ToListAsync();
        return list.Select(x => x.Map());
    }

    public async Task<LinkModel> GetByAction(string action)
    {
        var item = await _linkRepository.Get(p => p.Action == action);
        return item.Map();
    }

    public async Task<LinkModel> Update(Guid id, CreateLinkModel model)
    {
        var item = await _linkRepository.Get(p => p.Id == id);
        item = await _linkRepository.Update(item);
        return item.Map();
    }

    public async Task Delete(Guid id)
    {
        await _linkRepository.Delete(p => p.Id == id);
    }
}