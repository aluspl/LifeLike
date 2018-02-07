using System;
using LifeLike.Data.Models;

namespace LifeLike.Web.ViewModel
{
    public class EventLogApiModel
    {
        public int Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
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
        public static EventLog Generate(WebHookDataModel model)
        {
            return new EventLog
            {
                Type=EventLogType.Unity,
                Messages=$"Unity Project: {model?.projectName}, Platform: {model?.platform}",
                EventTime=DateTime.Now
            };
        }


    }
    

}