using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    public class EventLogsRepository : IEventLogRepository
    {
        private readonly PortalContext _context;

        public EventLogsRepository(PortalContext context)
        {
            _context = context;
        }

        public async Task<Result> AddException(Exception e)
        {
            try
            {
                Debug.WriteLine(e);

                return await Create(EventLogEntity.Generate(e));
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

        public async Task<Result> Add(EventLogEntity model)
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

        public async Task<Result> Create(EventLogEntity model)
        {
            try
            {
                await _context.EventLogs.AddAsync(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                return Result.Success;
            }
        }

        public async Task<IEnumerable<EventLogEntity>> List()
        {
            return await _context.EventLogs.ToListAsync();
        }

        public async Task<IEnumerable<EventLogEntity>> List(EventLogType type)
        {
            return await _context.EventLogs.Where(p => p.Type == type).ToListAsync();
        }

        public async Task<Result> LogInformation(int i, string information)
        {
            try
            {
                return await Create(EventLogEntity.Generate(i, information));
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
                await Create(EventLogEntity.Generate(result, message));
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
                _context.EventLogs.RemoveRange(_context.EventLogs.Where(p => p.Type != EventLogType.Statistic));

                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await AddException(e);
                throw;
            }
        }

        public async Task<EventLogEntity> Get(long id)
        {
            return await _context.EventLogs.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Result> Update(EventLogEntity model)
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

        public async Task<Result> Delete(EventLogEntity model)
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

    public interface IEventLogRepository : IRepository<EventLogEntity>
    {
        Task<Result> AddException(Exception e);
        Task<Result> AddStat(string id, string action, string controller);
        Task<Result> AddStat(string action, string controller);

        Task<IEnumerable<EventLogEntity>> List(EventLogType type);
        Task<Result> LogInformation(EventLogType result, string message);
        Task<Result> ClearLogs();
        Task<Result> Add(EventLogEntity eventLog);
    }
}