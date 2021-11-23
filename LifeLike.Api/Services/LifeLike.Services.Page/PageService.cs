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
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services.Page
{
    public class PageService : QueryPageService, IPageService
    {
        private readonly ILinkService _linkService;

        public PageService(
            IRepository<PageEntity> repository,
            ILinkService linkService,
            IMapper mapper)
            : base(repository, mapper)
        {
            _linkService = linkService;
        }

        public async Task<PageReadModel> Create(PageWriteModel model)
        {
            await ValidateShortname(model);
            var item = PageEntity.New(model.ShortName, model.FullName);

            item = await _repository.Add(item);
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

        private async Task ValidateShortname(PageWriteModel model)
        {
            if (await _repository.Any(p => p.Shortname == model.ShortName))
            {
                model.ShortName = $"{model.ShortName}+ 1";
            }
        }
    }
}
