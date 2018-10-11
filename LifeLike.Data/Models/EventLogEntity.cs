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