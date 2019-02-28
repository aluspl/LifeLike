using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.Structures;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeLike.Services
{

    public class LinkRepository : BaseService<LinkEntity>, ILinkService
    {
        private ILogService _logger;

        public LinkRepository(IUnitOfWork work, ILogService logger, IMapper mapper) : base(work, mapper)
        {
            _logger = logger;
        }

        public Result Create(Link model)
        {
            try
            {
                var item = _mapper.Map<LinkEntity>(model);
                CreateEntity(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);

                return Result.Failed;
            }
        }

        public IEnumerable<Link> List()
        {
            try
            {
                var items = GetAllEntities();
                return _mapper.Map<IEnumerable<Link>>(items);
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                throw;
            }
        }
        public IEnumerable<Link> List(LinkCategory category)
        {
            try
            {
                return _repo.GetOverviewQuery(q => q.Category == category).ProjectTo<Link>().AsEnumerable();
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                throw;
            }
        }

        public Link Get(long id)
        {
            var item = GetEntity(p => p.Id == id);
            return _mapper.Map<Link>(item);
        }
        public Link Get(string id)
        {
            var item = GetEntity(p => p.Action == id);
            return _mapper.Map<Link>(item);
        }
        public Result Update(Link model)
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

        public Result Delete(Link model)
        {
            try
            {
                DeleteEntity(p => p.Id == model.Id);
                return Result.Success;

            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }
        public Result Delete(string shortName)
        {
            try
            {
                DeleteEntity(p => p.Action == shortName);
                return Result.Success;

            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }



    }

    public interface ILinkService
    {
        IEnumerable<Link> List(LinkCategory category);
        Link Get(string id);
        Result Delete(string shortName);
        Result Create(Link link);
        IEnumerable<Link> List();
        Link Get(long id);
        Result Update(Link model);
    }
}