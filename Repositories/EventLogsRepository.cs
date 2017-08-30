using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Repositories;

namespace LifeLIke.Repositories
{
    public class EventLogsRepository : IEventLogRepository
    {
        private readonly PortalContext _context;

        public EventLogsRepository(PortalContext context)
        {
            _context = context;
        }
        
        public void AddExceptionLog(Exception e)
        {
           
            Create(EventLog.Generate(e));
          
        }

        public void AddStat(string id,string action, string controller)
        {
            Create(EventLog.Generate(id, action, controller));
        }

        public Result Create(EventLog model)
        {
            try
            {
             
                _context.EventLogs.Add(model);
                _context.SaveChanges();    
                return Result.Success;
            }
            catch (Exception e)
            {
                AddExceptionLog(e);
                return Result.Success;
            }        
        }

        public IEnumerable<EventLog> List()
        {
            return _context.EventLogs.ToList();
        }

        public IEnumerable<EventLog> List(EventLogType type)
        {
            return _context.EventLogs.Where(p => p.Type == type).ToList();
        }

        public void LogInformation(int i, string userLoggedOut)
        {
            
            
        }

        public void LogInformation(EventLogType result, string message)
        {

            Create(EventLog.Generate(result,message));
        }

        public void ClearLogs()
        {
            _context.EventLogs.RemoveRange(_context.EventLogs.Where(p=>p.Type!=EventLogType.Statistic));            
           
            _context.SaveChanges();
             
        }

        public EventLog Get(long id)
        {
            return _context.EventLogs.FirstOrDefault(p=>p.Id==id);
        }

        public Result Update(EventLog model)
        {
            try
            {
                _context.Update(model);
                _context.SaveChanges();
                return Result.Success;

            }
            catch (Exception e)
            {
                AddExceptionLog(e);
                return Result.Failed;
            }
            
        }

        public Result Delete(EventLog model)
        {
            try
            {
                _context.Remove(model);
                _context.SaveChanges();
                return Result.Success;

            }
            catch (Exception e)
            {
                AddExceptionLog(e);
                return Result.Failed;
            }
        }
    }
    
    public interface IEventLogRepository : IRepository<EventLog>
    {
        void AddExceptionLog(Exception e);
        void AddStat(string id, string action, string controller);
        IEnumerable<EventLog> List(EventLogType type);
        void LogInformation(int i, string userLoggedOut);
        void LogInformation(EventLogType result, string message);
        void ClearLogs();
    }
}