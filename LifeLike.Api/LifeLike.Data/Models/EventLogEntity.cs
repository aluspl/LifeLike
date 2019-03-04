using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class EventLogEntity : IEntity
    {
        [Key]
        public string Id { get; set; }
        public EventLogType Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace { get; set; }
        public DateTime EventTime { get; set; }
    }  
}