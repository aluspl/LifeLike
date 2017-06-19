using System;
using System.Diagnostics;
using LifeLike.ApiModels;

namespace LifeLike.Models
{
    public class EventLogDataModel
    {
        public long Id { get; set; }
        public EventLogType Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
        public DateTime EventTime { get; set;  }

        public static EventLogDataModel Generate(EventLogApiModel model)
        {
            return new EventLogDataModel
            {
                 Type = (EventLogType)model.Type,
                Messages = model.Messages,
                StackTrace = model.StackTrace,
                EventTime=DateTime.Now
            };
        }

        public static EventLogDataModel Generate(Exception model)
        {
            return new EventLogDataModel
            {
                EventTime = DateTime.Now,
                Type = EventLogType.Error,
                Messages = model.Message,
                StackTrace = model.StackTrace
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