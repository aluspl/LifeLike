using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using System;
using System.Collections.Generic;

namespace LifeLike.Repositories
{
    public class PageService : BaseService<PageEntity>, IPageService
    {
        private readonly ILinkService _link;
        private readonly ILogService _logger;

        public PageService(IUnitOfWork work,
            ILogService logger,
            ILinkService link,
            IMapper mapper) : base(work, mapper)
        {
            _link = link;
            _logger = logger;
        }

        public Result Create(Page model)
        {
            try
            {
                var item = _mapper.Map<PageEntity>(model);

                if (IsAnyEntity(p => p.ShortName == model.ShortName))
                    item.ShortName = model.ShortName + 1;
                CreateEntity(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }

        public Result Create(Page model, Link link)
        {
            try
            {
                _link.Create(link);
                Create(model);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }

        public IEnumerable<Page> List()
        {
            try
            {
                var items = GetAllEntities();
                return _mapper.Map<IEnumerable<Page>>(items);
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                throw;
            }
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
            try
            {
                var item = GetEntity(p => p.Id == model.Id);
                _mapper.Map(model, item);
                UpdateEntity(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }



        public Result Delete(long id)
        {
            try
            {
                var model = GetEntity(p => p.Id == id);
                if (model == null) return Result.Failed;
                _link.Delete(model.ShortName);
                DeleteEntity(query => query.Id == model.Id);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);

                return Result.Failed;
            }
        }

        public IEnumerable<Page> List(PageCategory category)
        {
            try
            {
                var items = _repo.GetOverview(p => p.Category == category);
                return _mapper.Map<IEnumerable<Page>>(items);
            }
            catch (Exception e)
            {
                _logger.AddException(e);

                return new List<Page>();
            }
        }
    }

    public interface IPageService
    {
        IEnumerable<Page> List(PageCategory category);
        Page Get(string id);
        Result Create(Page model, Link link);
        Result Delete(long id);
        Result Update(Page model);
        IEnumerable<Page> List();
    }
}