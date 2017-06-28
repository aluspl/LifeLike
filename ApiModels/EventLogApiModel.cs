using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using LifeLike.Models;

namespace LifeLike.ApiModels
{
    public class EventLogApiModel
    {
        public int Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
    }

}