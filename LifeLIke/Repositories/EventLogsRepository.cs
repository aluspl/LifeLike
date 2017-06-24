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

        public Result Create(EventLog model)
        {
            try
            {
             
                _context.EventLogs.Add(model);
                _context.SaveChanges();    
                return Result.Success;
            }
            catch (Exception exception)
            {
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
        IEnumerable<EventLog> List(EventLogType type);
    }
}