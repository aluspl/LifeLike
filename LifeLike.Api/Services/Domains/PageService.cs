using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using System;
using System.Collections.Generic;

namespace LifeLike.Repositories
{
    public class PageService : BaseService<PageEntity>, IPageService
    {
        private readonly ILinkService _link;

        public PageService(IRepository<PageEntity> repository,
            ILinkService link,
            IMapper mapper) : base(repository, mapper)
        {
            _link = link;
        }

        public Result Create(Page model)
        {
            var item = _mapper.Map<PageEntity>(model);

            if (IsAnyEntity(p => p.ShortName == model.ShortName))
                item.ShortName = model.ShortName + 1;
            CreateEntity(item);
            return Result.Success;

        }

        public Result Create(Page model, Link link)
        {
            _link.Create(link);
            Create(model);
            return Result.Success;
        }

        public IEnumerable<Page> List()
        {
            var items = GetAllEntities();
            return _mapper.Map<IEnumerable<Page>>(items);
        }

        private Page GetItem(Page model)
        {
            var item = GetEntity(p => p.Id == model.Id);
            return _mapper.Map<Page>(item);
        }

        public Page Get(long id)
        {
            var item = GetEntity(p => p.LinkId == id);
            return _mapper.Map<Page>(item);
        }

        public Page Get(string id)
        {
            var item = GetEntity(p => p.ShortName == id);
            return _mapper.Map<Page>(item);
        }
        public bool Any(string id)
        {
            return IsAnyEntity(p => p.ShortName == id);
        }
        public Result Update(Page model)
        {
            var item = GetEntity(p => p.Id == model.Id);
            _mapper.Map(model, item);
            UpdateEntity(item);
            return Result.Success;
        }

        public Result Delete(string id)
        {
            var model = GetEntity(p => p.Id == id);
            if (model == null)
                return Result.Failed;
            _link.Delete(model.ShortName);
            DeleteEntity(query => query.Id == model.Id);
            return Result.Success;
        }

        public IEnumerable<Page> List(PageCategory category)
        {
            var items = _repo.GetOverview(p => p.Category == category);
            return _mapper.Map<IEnumerable<Page>>(items);
        }
    }
}