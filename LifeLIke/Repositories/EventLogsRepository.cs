using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Repositories;

namespace LifeLIke.Repositories
{
    public class EventLogsRepository : IEventLogRepository
    {
        private readonly LifeLikeContext _context;

        public EventLogsRepository(LifeLikeContext context)
        {
            _context = context;
        }
        
        public void AddExceptionLog(Exception e)
        {
            try
            {
             
               _context.EventLogs.Add(EventLogDataModel.Generate(e));
               _context.SaveChanges();                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public IEnumerable<EventLogDataModel> List()
        {
            return _context.EventLogs.ToList();
        }

        public IEnumerable<EventLogDataModel> List(EventLogType type)
        {
            return _context.EventLogs.Where(p => p.Type == type).ToList();
        }

        public EventLogDataModel Get(long id)
        {
            return _context.EventLogs.FirstOrDefault(p=>p.Id==id);
        }

        public Result Update(EventLogDataModel model)
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

        public Result Delete(EventLogDataModel model)
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
    
    public interface IEventLogRepository : IRepository<EventLogDataModel>
    {
        void AddExceptionLog(Exception e);
        IEnumerable<EventLogDataModel> List(EventLogType type);
    }
}