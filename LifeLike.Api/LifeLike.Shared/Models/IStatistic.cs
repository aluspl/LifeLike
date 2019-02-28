using System;

namespace LifeLike.Shared.Models
{
    public interface IStatistic
    {
        string RowKey { get; set; }
        string Action { get; set; }
        string Controller { get; set; }
        
    }
}