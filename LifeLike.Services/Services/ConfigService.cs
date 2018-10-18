using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeLike.Data;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.ViewModel;
using Microsoft.EntityFrameworkCore;

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

      

        public Config Get(long id)
        {
            var item = _repo.GetDetail(p => p.Id == id);
            return _mapper.Map<Config>(item);
        }

        public Result Update(Config model)
        {
            try
            {
                ConfigEntity item = GetEntity(p => p.Name == model.Name);
                _mapper.Map(model, item);
                _repo.Update(item);
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

        public Config Get(string id)
        {
            try
            {
                var item = GetEntity(p => p.Name == id);
                return _mapper.Map<Config>(item);
            }
            catch (Exception e)
            {
                log.AddException(e);
                return null;
            }
        }

        public IEnumerable<Config> List()
        {
            var items= GetAllEntities();
            return _mapper.Map<IEnumerable<Config>>(items);

        }

       
    }

    public interface IConfigService 
    {
        Result Create(Config model);
        Config Get(string id);
        IEnumerable<Config> List();
        Result Update(Config model);
    }
}