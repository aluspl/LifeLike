using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Config;
using Microsoft.Extensions.Logging;

namespace LifeLike.Services.Domain.Services
{
    public class ConfigService : BaseService, IConfigService
    {
        private readonly IRepository<ConfigEntity> _configRepository;
        private readonly ILogger<ConfigService> _log;

        public ConfigService(IRepository<ConfigEntity> configRepository,
            ILogger<ConfigService> logger,
            IMapper mapper)
            : base(mapper)
        {
            _configRepository = configRepository;
            _log = logger;
        }

        public async Task<ConfigReadModel> Create(ConfigWriteModel model)
        {
            var configEntity = _mapper.Map<ConfigEntity>(model);
            configEntity = await _configRepository.Add(configEntity);
            var result =  _mapper.Map<ConfigReadModel>(configEntity);
            return result;
        }

        public async Task<ConfigReadModel> Get(Guid id)
        {
            var item = await _configRepository.Get(p => p.Id == id);
            return _mapper.Map<ConfigReadModel>(item);
        }

        public async Task<ConfigReadModel> Update(ConfigWriteModel model)
        {
            var item = await _configRepository.Get(p => p.Name == model.Name);
            _mapper.Map(model, item);
            item = await _configRepository.Update(item);
            return _mapper.Map<ConfigReadModel>(item);
        }

        public async Task Delete(Guid id)
        {
            await _configRepository.Delete(p => p.Id == id);
        }

        public async Task<IList<ConfigReadModel>> List()
        {
            var items = await _configRepository.GetAll();
            return _mapper.Map<IList<ConfigReadModel>>(items);
        }
    }
}
