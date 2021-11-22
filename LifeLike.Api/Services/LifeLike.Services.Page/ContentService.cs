using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Enums;
using LifeLike.Common.Extensions;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Video;
using LifeLike.Services.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services.Page
{
    public class ContentService : BaseService, IContentService
    {
        private readonly IRepository<ContentEntity> _repo;

        public ContentService(IRepository<ContentEntity> repo, IMapper mapper) : base(mapper)
        {
            _repo = repo;
        }

        public async Task<ContentReadModel> Create(ContentWriteModel model)
        {
            var item = _mapper.Map<ContentEntity>(model);
            item = await _repo.Add(item);
            return _mapper.Map<ContentReadModel>(item);
        }

        public async Task<IEnumerable<ContentReadModel>> List()
        {
            var items = await _repo.GetAll();
            Debug.WriteLine(items.ToJSON());
            return _mapper.Map<IEnumerable<ContentReadModel>>(items);
        }

        public async Task<IEnumerable<ContentReadModel>> ListByCategory(ContentCategory category)
        {
            var items = await _repo.Find(p => p.Category == category).ToListAsync();
            Debug.WriteLine(items.ToJSON());
            return _mapper.Map<IEnumerable<ContentReadModel>>(items);
        }

        public async Task<ContentReadModel> Get(Guid id)
        {
            var item = await _repo.Get(o => o.Id == id);
            return _mapper.Map<ContentReadModel>(item);
        }

        public async Task<ContentReadModel> Update(Guid id, ContentWriteModel model)
        {
            var item = await _repo.Get(o => o.Id == id);
            _mapper.Map(model, item);
            item = await _repo.Update(item);
            _mapper.Map(model, item);
            return _mapper.Map<ContentReadModel>(item);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(o => o.Id == id);
        }
    }
}
