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

namespace LifeLike.Repositories
{
    public class EventLogsRepository : IEventLogRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalContext _context;

        public EventLogsRepository(PortalContext context, IMapper mapper)
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
                await _context.EventLogs.AddAsync(_mapper.Map<EventLogEntity>(model));
                await _context.SaveChangesAsync();
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
            return await _context.EventLogs.ProjectTo<Log>().ToListAsync();
        }

        public async Task<IEnumerable<Log>> List(EventLogType type)
        {
            return await _context.EventLogs.Where(p => p.Type == type).ProjectTo<Log>().ToListAsync();
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
            return await _context.EventLogs.Where(p => p.Id == id).ProjectTo<Log>().FirstOrDefaultAsync();
        }

        public async Task<Result> Update(Log model)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> Delete(Log model)
        {
            try
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> DeleteAll()
        {
            try
            {
                _context.EventLogs.RemoveRange(_context.EventLogs.ToList());
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }
        }
    }

    public interface IEventLogRepository : IRepository<Log>
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