﻿using LifeLike.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class StatisticEntity : Entity
    {       
        public  string Action { get; set; }
        public  string Controller { get; set; }
        public  string Parameter { get; set; }
        public StatisticType Type { get; set; }
    }

    public enum StatisticType
    {
        Info=0,
        Error=1,
        Warning=2,
        Statistic=4,
        Unity = 8,
        Method
    }
    
}