using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class LogService : ILogService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EventLogEntity> _context;

        public LogService(IRepository<EventLogEntity> context, IMapper mapper)
        {
            _mapper =mapper;
            _context = context;
        }

        public async Task<Result> AddException(Exception e)
        {
            try
            {
                Debug.WriteLine(e);

                return await Create(Log.Generate(e));
            }
            catch (Exception)
            {
                Debug.WriteLine(e);
                return Result.Failed;
            }
        }

        public async Task<Result> AddStat(string action, string controller)
        {
            try
            {
                return await AddStat(string.Empty, action, controller);
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }

        public async Task<Result> AddStat(string id, string action, string controller)
        {
            try
            {
                var model = new StatisticEntity
                {
                    Action = action,
                    Controller = controller,
                    Type = StatisticType.Method
                };
                await _context.Stats.AddAsync(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }

        public async Task<Result> Add(Log model)
        {
            try
            {
                return await Create(model);
            }
            catch (Exception)
            {
                return Result.Success;
            }
        }

        public async Task<Result> Create(Log model)
        {
            try
            {
                 _context.Add(_mapper.Map<EventLogEntity>(model));
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Success;
            }
        }

        public async Task<IEnumerable<Log>> List()
        {
            return await _context.GetOverviewQuery().ProjectTo<Log>().ToListAsync();
        }

        public IEnumerable<Log> List(EventLogType type)
        {
            return _context.GetOverviewQuery(p => p.Type == type).ProjectTo<Log>().AsEnumerable();
        }

        public async Task<Result> LogInformation(int i, string information)
        {
            try
            {
                return await Create(Log.Generate(i, information));
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> LogInformation(EventLogType result, string message)
        {
            try
            {
                await Create(Log.Generate(result, message));
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> ClearLogs()
        {
            try
            {
                await DeleteAll();
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                throw;
            }
        }

        public async Task<Log> Get(long id)
        {
            var item = _context.GetDetail(p => p.Id == id);
            return _mapper.Map<Log>(item);
        }

        public async Task<Result> Update(Log model)
        {
            try
            {
                EventLogEntity item = GetEntity(model.Id);
                _mapper.Map(model, item);
                _context.Update(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> Delete(long id)
        {
            try
            {
                EventLogEntity item = GetEntity(id);
                _context.Delete(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }

        private EventLogEntity GetEntity(long id)
        {
            return _context.GetDetail(p => p.Id == id);
        }

        public async Task<Result> DeleteAll()
        {
            try
            {
                _context.DeleteAll();
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }
    }

    public interface ILogService 
    {
        Task<Result> AddException(Exception e);
        Task<Result> AddStat(string id, string action, string controller);
        Task<Result> AddStat(string action, string controller);

        Task<IEnumerable<Log>> List(EventLogType type);
        Task<Result> LogInformation(EventLogType result, string message);
        Task<Result> ClearLogs();
        Task<Result> Add(Log eventLog);
    }
}