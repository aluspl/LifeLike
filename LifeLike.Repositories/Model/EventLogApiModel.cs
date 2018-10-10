using System;
using LifeLike.Data.Models;

namespace LifeLike.Repositories.ViewModel
{
    public class EventLogApiModel
    {
        public int Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
        public static EventLogEntity Generate(EventLogApiModel model)
        {
            return new EventLogEntity
            {
                Type = (EventLogType)model.Type,
                Messages = model.Messages,
                StackTrace = model.StackTrace,
                EventTime=DateTime.Now
            };
        }
      

    }
    

}