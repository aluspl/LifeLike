using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Enums;
using LifeLike.Database.Data.Entities.Link;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Link;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LifeLike.Services.Domain.Services
{
    public class LinkService : BaseService, ILinkService
    {
        private readonly IRepository<LinkEntity> _linkRepository;
        private ILogger<LinkService> _logger;

        public LinkService(IRepository<LinkEntity> linkRepository, ILogger<LinkService> logger, IMapper mapper)
            : base(mapper)
        {
            _linkRepository = linkRepository;
            _logger = logger;
        }

        public async Task<LinkReadModel> Create(LinkWriteModel model)
        {
            var item = _mapper.Map<LinkEntity>(model);
            await _linkRepository.Add(item);
            var returnModel = _mapper.Map<LinkReadModel>(model);
            return returnModel;
        }

        public async Task<IEnumerable<LinkReadModel>> List()
        {
            var items = await _linkRepository.GetAll();
            return _mapper.Map<IEnumerable<LinkReadModel>>(items);
        }

        public async Task<IEnumerable<LinkReadModel>> List(LinkCategory category)
        {
            var list = await _linkRepository.Find(q => q.Category == category).ToListAsync();
            return _mapper.Map<IEnumerable<LinkReadModel>>(list);
        }

        public async Task<LinkReadModel> GetByAction(string action)
        {
            var item = await _linkRepository.Get(p => p.Action == action);
            return _mapper.Map<LinkReadModel>(item);
        }

        public async Task<LinkReadModel> Update(Guid id, LinkWriteModel model)
        {
            var item = await _linkRepository.Get(p => p.Id == id);
            _mapper.Map(model, item);
            item = await _linkRepository.Update(item);

            var response = _mapper.Map<LinkReadModel>(item);
            return response;
        }

        public async Task Delete(Guid id)
        {
            await _linkRepository.Delete(p => p.Id == id);
        }
    }
}
