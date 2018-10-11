using System;
using LifeLike.Data.Models;

namespace LifeLike.Repositories.ViewModel
{
    public class Log
    {
        public  long Id { get; set; }
        public EventLogType Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
        public DateTime EventTime { get; set;  }
       
         public static Log Generate(Exception model)
        {
            return new Log
            {
                EventTime = DateTime.Now,
                Type = EventLogType.Error,
                Messages = model.Message,
                StackTrace = model.StackTrace
            };
        }

      
        public static Log Generate(EventLogType result, string message)
        {
              return new Log
                        {
                            Type = result,
                            Messages = message,
                            EventTime=DateTime.Now
                        };        
        }

        public static Log Generate(string id, string action, string controller)
        {
            return new Log
            {
                Type = EventLogType.Statistic,
                Messages = $"{id}; {action}; {controller}",
                EventTime=DateTime.Now
            };                
        }

        public static Log Generate(int i, string information)
        {
             return new Log
            {
                Type = EventLogType.Info,
                Messages = $"{i}; {information}",
                EventTime=DateTime.Now
            };          
        }
    }
}