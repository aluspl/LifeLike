using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Exceptions;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services.Page
{
    public class QueryPageService : BaseService, IQueryPageService
    {
        protected readonly IRepository<PageEntity> _repository;

        public QueryPageService(
            IRepository<PageEntity> repository,
            IMapper mapper)
            : base(mapper)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PageReadModel>> List()
        {
            var items = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PageReadModel>>(items);
        }

        public async Task<PageReadModel> Get(Guid id)
        {
            var item = await _repository.Get(p => p.LinkId == id);
            return _mapper.Map<PageReadModel>(item);
        }

        public async Task<PageReadModel> Get(string shortName)
        {
            var item = await GetEntity(p => p.Shortname == shortName);
            return _mapper.Map<PageReadModel>(item);
        }

        public async Task<IEnumerable<PageReadModel>> ListByCategory(Guid categoryId)
        {
            var items = await _repository
                .Find(p => p.Categories.Any(entity => entity.Id == categoryId))
                .ToListAsync();
            return _mapper.Map<IEnumerable<PageReadModel>>(items);
        }

        protected async Task<PageEntity> GetEntity(Expression<Func<PageEntity, bool>> predicate)
        {
            return await _repository.Get(predicate)  ?? throw new NotFoundException($"Page not found");
        }
    }
}
