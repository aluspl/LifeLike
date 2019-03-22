using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services.Structures;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;

namespace LifeLike.Services
{
    public class ConfigService : BaseService<ConfigEntity>, IConfigService
    {
        private readonly ILogService log;

        public ConfigService(IUnitOfWork context, ILogService logger, IMapper mapper) : base(context, mapper)
        {            
            log = logger;
        }

        public Result Create(Config model)
        {
            try
            {
                _repo.Add(_mapper.Map<ConfigEntity>(model));
                return Result.Success;
            }
            catch (Exception e)
            {
                log.AddException(e);
                return Result.Failed;
            }
        }
      
        public Config Get(string id)
        {
            var item = _repo.GetDetail(p => p.Id == id);
            return _mapper.Map<Config>(item);
        }

        public Result Update(Config model)
        {
            try
            {
                var item = GetEntity(p => p.Name == model.Name);
                _mapper.Map(model, item);
                _repo.Update(item,item);
                return Result.Success;
            }
            catch (Exception e)
            {
                log.AddException(e);
                return Result.Failed;
            }
        }

        public Result Delete(string id)
        {
            try
            {
                DeleteEntity(p => p.Name == id);
                return Result.Success;
            }
            catch (Exception e)
            {
                log.AddException(e);
                return Result.Failed;
            }
        }
     
        public IList<Config> List()
        {
            var items = GetAllEntities().ToList();
            return _mapper.Map<IList<Config>>(items);
        }
        public Result DeleteAll()
        {
            return DeleteAll();
        }
       
    }

    public interface IConfigService 
    {
        Result Create(Config model);
        Result Delete(string id);
        Config Get(string id);
        IList<Config> List();
        Result Update(Config model);
        Result DeleteAll();
    }
}