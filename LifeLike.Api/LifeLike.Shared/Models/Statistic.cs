using System;
using System.Collections.Generic;
using System.Text;

namespace LifeLike.Shared.Models
{
    public class Statistic : IStatistic
    {
        public string Id { get; set; }
        public string RowKey { get; set; }
        public string Params { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string PartitionKey { get; set; }
    }
}
