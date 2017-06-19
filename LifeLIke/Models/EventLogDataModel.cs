using System;
using System.Diagnostics;
using LifeLike.ApiMOdels;

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
    }

    public enum EventLogType
    {
        Notification,
        Error,
        Warning
    }
    
}