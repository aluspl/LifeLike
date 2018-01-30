using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
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

               return await Create(EventLog.Generate(e));          
            }
            catch (System.Exception)
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
            catch (System.Exception)
            {
                return Result.Failed;
            }
        }
        public async Task<Result> AddStat(string id,string action, string controller)
        {
            try
            {
                var model = new Statistic
                {
                    Action = action,
                    Controller = controller,
                    Type = StatisticType.Method
                };
                await _context.Stats.AddAsync(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (System.Exception)
            {
                return Result.Failed;
            }
        }
        public async Task<Result> Add(EventLog model)
        {
            try
            {             
               return  await Create(model);
            }
            catch (Exception)
            {
                return Result.Success;
            }        
        }
        public async Task<Result> Create(EventLog model)
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

        public async Task<IEnumerable<EventLog>> List()
        {
            return await _context.EventLogs.ToListAsync();
        }

        public async Task<IEnumerable<EventLog>> List(EventLogType type)
        {
            return await _context.EventLogs.Where(p => p.Type == type).ToListAsync();
        }

        public async Task<Result> LogInformation(int i, string information)
        {
            try
            {
                return await Create(EventLog.Generate(i,information));

            }
            catch (System.Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }   
     }

        public async Task<Result> LogInformation(EventLogType result, string message)
        {
            try
            {
                await Create(EventLog.Generate(result,message));
                return Result.Success;
            }
            catch (System.Exception e)
            {
                await AddException(e);
                return Result.Failed;
            }

        }

        public async Task<Result>  ClearLogs()
        {
            try
            {
                  _context.EventLogs.RemoveRange(_context.EventLogs.Where(p=>p.Type!=EventLogType.Statistic));            
           
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (System.Exception)
            {
                
                throw;
            }
          
             
        }

        public  async Task<EventLog> Get(long id)
        {
            return await _context.EventLogs.FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<Result> Update(EventLog model)
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

        public async Task<Result> Delete(EventLog model)
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
    
    public interface IEventLogRepository : IRepository<EventLog>
    {
        Task<Result> AddException(Exception e);
        Task<Result> AddStat(string id, string action, string controller);
        Task<Result> AddStat(string action, string controller);

        Task<IEnumerable<EventLog>> List(EventLogType type);
        Task<Result>  LogInformation(EventLogType result, string message);
        Task<Result> ClearLogs();
        Task<Result> Add(EventLog eventLog);
    }
}