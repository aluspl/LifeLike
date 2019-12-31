using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeLike.Data.Models;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeLike.Services
{

    public class LinkService : BaseService<LinkEntity>, ILinkService
    {
        private ILogger<LinkService> _logger;

        public LinkService(IRepository<LinkEntity> work, ILogger<LinkService> logger, IMapper mapper) : base(work, mapper)
        {
            _logger = logger;
        }

        public Result Create(Link model)
        {
            var item = _mapper.Map<LinkEntity>(model);
            CreateEntity(item);
            return Result.Success;
        }

        public IEnumerable<Link> List()
        {

            var items = GetAllEntities();
            return _mapper.Map<IEnumerable<Link>>(items);
        }

        public IEnumerable<Link> List(LinkCategory category)
        {
            var list = _repo.GetOverviewQuery(q => q.Category == category).ToList();
            return _mapper.Map<IEnumerable<Link>>(list);
        }
        public Link Get(string id)
        {
            var item = GetEntity(p => p.Action == id);
            return _mapper.Map<Link>(item);
        }

        public Result Update(Link model)
        {

            var item = GetEntity(p => p.Id == model.Id);
            _mapper.Map(model, item);
            UpdateEntity(item);
            return Result.Success;
        }

        public Result Delete(Link model)
        {
            DeleteEntity(p => p.Id == model.Id);
            return Result.Success;
        }
        public Result Delete(string shortName)
        {
            DeleteEntity(p => p.Action == shortName);
            return Result.Success;
        }
    }
}