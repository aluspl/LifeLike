using LifeLike.Shared.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace LifeLike.CloudService.TableStorage
{
    public class StatisticEntity : TableEntity
    {
        public static string KEY = "STAT";
        public string Action { get; set; }
        public string Params { get; set; }
        public string Controller { get; set; }

        public StatisticEntity()
        {
            RowKey = Guid.NewGuid().ToString();
            PartitionKey = KEY;
        }

        internal static Statistic Convert(StatisticEntity item)
        {
            return new Statistic
            {
                Action = item.Action,
                Controller = item.Controller,
                Params = item.Params,
                RowKey = item.RowKey,
                PartitionKey = item.PartitionKey
            };
        }
        internal static StatisticEntity Convert(Statistic item)
        {
            return new StatisticEntity
            {
                Action = item.Action,
                Controller = item.Controller,
                Params = item.Params,
                RowKey = item.RowKey,
                PartitionKey = item.PartitionKey
            };
        }
    }
}