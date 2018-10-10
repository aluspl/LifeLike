using System;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class EventLogEntity
    {
        [Key]
        public long Id { get; set; }
        public EventLogType Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
        public DateTime EventTime { get; set;  }

      
        public static EventLogEntity Generate(Exception model)
        {
            return new EventLogEntity
            {
                EventTime = DateTime.Now,
                Type = EventLogType.Error,
                Messages = model.Message,
                StackTrace = model.StackTrace
            };
        }

      
        public static EventLogEntity Generate(EventLogType result, string message)
        {
              return new EventLogEntity
                        {
                            Type = result,
                            Messages = message,
                            EventTime=DateTime.Now
                        };        
        }

        public static EventLogEntity Generate(string id, string action, string controller)
        {
            return new EventLogEntity
            {
                Type = EventLogType.Statistic,
                Messages = $"{id}; {action}; {controller}",
                EventTime=DateTime.Now
            };                
        }

        public static EventLogEntity Generate(int i, string information)
        {
             return new EventLogEntity
            {
                Type = EventLogType.Info,
                Messages = $"{i}; {information}",
                EventTime=DateTime.Now
            };          
        }
    }

    public enum EventLogType
    {
        Info=0,
        Error=1,
        Warning=2,
        Statistic=4,
        Unity = 8
    }
    
}