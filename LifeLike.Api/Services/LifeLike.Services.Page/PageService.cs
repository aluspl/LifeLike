using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Exceptions;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services.Page
{
    public class PageService : BaseService, IPageService
    {
        private readonly IRepository<PageEntity> _repository;
        private readonly ILinkService _linkService;

        public PageService(
            IRepository<PageEntity> repository,
            ILinkService linkService,
            IMapper mapper)
            : base(mapper)
        {
            _repository = repository;
            _linkService = linkService;
        }

        public async Task<PageReadModel> Create(PageWriteModel model)
        {
            var item = _mapper.Map<PageEntity>(model);

            if (await _repository.Any(p => p.ShortName == model.ShortName))
            {
                item.ShortName = $"{model.ShortName}+ 1";
            }

            item = await _repository.Add(item);
            return _mapper.Map<PageReadModel>(item);
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
            var item = await GetEntity(p => p.ShortName == shortName);
            return _mapper.Map<PageReadModel>(item);
        }

        public async Task<PageReadModel> Update(Guid id, PageWriteModel model)
        {
            var item = await GetEntity(p => p.Id == id);
            _mapper.Map(model, item);
            item = await _repository.Update(item);
            var result = _mapper.Map<PageReadModel>(item);
            return result;
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

        public async Task<IEnumerable<PageReadModel>> ListByCategory(Guid categoryId)
        {
            var items = await _repository
                .Find(p => p.Categories.Any(p => p.Id == categoryId))
                .ToListAsync();
            return _mapper.Map<IEnumerable<PageReadModel>>(items);
        }

        private async Task<PageEntity> GetEntity(Expression<Func<PageEntity, bool>> predicate)
        {
            return await _repository.Get(predicate)  ?? throw new NotFoundException($"Page not found");
        }
    }
}
