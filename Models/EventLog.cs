using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using LifeLike.ApiModels;

namespace LifeLike.Models
{
    public class EventLog
    {
        [Key]
        public long Id { get; set; }
        public EventLogType Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
        public DateTime EventTime { get; set;  }

        public static EventLog Generate(EventLogApiModel model)
        {
            return new EventLog
            {
                Type = (EventLogType)model.Type,
                Messages = model.Messages,
                StackTrace = model.StackTrace,
                EventTime=DateTime.Now
            };
        }

        public static EventLog Generate(Exception model)
        {
            return new EventLog
            {
                EventTime = DateTime.Now,
                Type = EventLogType.Error,
                Messages = model.Message,
                StackTrace = model.StackTrace
            };
        }

        public static EventLog Generate(EventLogType result, string message)
        {
              return new EventLog
                        {
                            Type = result,
                            Messages = message,
                            EventTime=DateTime.Now
                        };        
        }
    }

    public enum EventLogType
    {
        Info=0,
        Error=1,
        Warning=2
    }
    
}