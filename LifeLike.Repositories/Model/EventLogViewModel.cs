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
        public static Log Get(EventLogEntity model)
        {
            return new Log
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