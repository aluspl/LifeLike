using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using Microsoft.Extensions.Logging;

namespace LifeLike.Services
{
    public class ConfigService : BaseService<ConfigEntity>, IConfigService
    {
        private readonly ILogger<ConfigService> log;

        public ConfigService(IRepository<ConfigEntity> context, ILogger<ConfigService> logger, IMapper mapper) : base(context, mapper)
        {            
            log = logger;
        }

        public Result Create(Config model)
        {
                _repo.Add(_mapper.Map<ConfigEntity>(model));
                return Result.Success;
        }
      
        public Config Get(string id)
        {
            var item = _repo.GetDetail(p => p.Id == id);
            return _mapper.Map<Config>(item);
        }

        public Result Update(Config model)
        {
                var item = GetEntity(p => p.Name == model.Name);
                _mapper.Map(model, item);
                _repo.Update(item);
                return Result.Success;         
        }

        public Result Delete(string id)
        {

                DeleteEntity(p => p.Name == id);
                return Result.Success;
        }
     
        public IList<Config> List()
        {
            var items = GetAllEntities().ToList();
            return _mapper.Map<IList<Config>>(items);
        }     
    }
}