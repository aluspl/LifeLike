using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLIke.Utils
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

        public IList<EventLogDataModel> GetAllLogs()
        {
            return _context.EventLogs.ToList();
        }

        public IList<EventLogDataModel> GetAllLogs(EventLogType type)
        {
            return _context.EventLogs.Where(p => p.Type == type).ToList();
        }

        public EventLogDataModel GetLog(long id)
        {
            return _context.EventLogs.FirstOrDefault(p=>p.Id==id);
        }
    }
    
    public interface IEventLogRepository
    {
        void AddExceptionLog(Exception e);
        IList<EventLogDataModel> GetAllLogs();
        IList<EventLogDataModel> GetAllLogs(EventLogType type);
        EventLogDataModel GetLog(long id);
    }
}