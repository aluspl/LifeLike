using System;
using System.Diagnostics;
using LifeLike.Models;

namespace LifeLike.ApiMOdels
{
    public class EventLogApiModel
    {
        public int Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace {  get; set; }
    }

}