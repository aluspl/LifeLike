using System;
using LifeLike.Models;

namespace LifeLike.ViewModel
{
    public class EventLogViewModel
    {
        public  long Id { get; set; }
        public EventLogType Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
        public DateTime EventTime { get; set;  }
        public static EventLogViewModel Get(EventLog model)
        {
            return new EventLogViewModel
            {
                Type = model.Type,
                EventTime = model.EventTime,
                Id = model.Id,
                Messages = model.Messages,
                StackTrace = model.StackTrace
            };

        }
    }
}