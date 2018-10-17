using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IMapper _mapper;
        private readonly ILogService log;
        private readonly IRepository<ConfigEntity> _context;

        public ConfigService(IRepository<ConfigEntity> context, ILogService logger, IMapper mapper)
        {
            _mapper = mapper;
            log = logger;
            _context = context;
        }


        public async Task<Result> Create(Config model)
        {
            try
            {
                _context.Add(_mapper.Map<ConfigEntity>(model));
                return Result.Success;
            }
            catch (Exception e)
            {
                await log.AddException(e);
                return Result.Failed;
            }
        }

        public async Task<IEnumerable<Config>> List()
        {
            try
            {
                var item = _context.GetOverview();
                 return null;
            }
            catch (Exception e)
            {
                await log.AddException(e);
                return new List<Config>();
            }
        }

        public async Task<Config> Get(long id)
        {
            var item = _context.GetDetail(p => p.Id == id);
            return _mapper.Map<Config>(item);
        }

        public async Task<Result> Update(Config model)
        {
            try
            {
                ConfigEntity item = GetEntity(model);
                _mapper.Map(model, item);
                _context.Update(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                await log.AddException(e);
                return Result.Failed;
            }
        }

        private ConfigEntity GetEntity(Config model)
        {
            return _context.GetDetail(predicate => predicate.Name == model.Name);
        }

        public async Task<Result> Delete(Config model)
        {
            try
            {
                ConfigEntity item = GetEntity(model);

                _context.Delete(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                await log.AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Config> Get(string id)
        {
            try
            {
                return await _context.GetOverviewQuery(p => p.Name == id).ProjectTo<Config>().FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                await log.AddException(e);
                return null;
            }
        }
    }

    public interface IConfigService 
    {
        Task Create(Config model);
        Task<Config> Get(string id);
        Task<IEnumerable<Config>> List();
        Task Update(Config model);
    }
}