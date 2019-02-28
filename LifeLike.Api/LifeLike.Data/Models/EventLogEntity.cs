using LifeLike.Shared.Enums;
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
        public string StackTrace { get; set; }
        public DateTime EventTime { get; set; }
    }  
}