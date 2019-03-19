using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace LifeLike.CloudService.TableStorage
{
    internal class ItemEntity : TableEntity
    {
        public string Messages { get; set; }
        public string Value { get; set; }
        public DateTime EventTime { get; set; }

        internal static ItemEntity Convert(Log item)
        {
            return new ItemEntity
            {

                RowKey = item.Id,
                PartitionKey = item.Type.ToString(),
                Value = item.StackTrace,
                Messages = item.Messages,
                EventTime = item.EventTime
            };
        }
        internal static Log Convert(ItemEntity item)
        {
            return new Log
            {
                Id = item.RowKey,
                Messages = item.Messages,
                StackTrace = item.Value,
                EventTime = item.EventTime,
                Type = Enum.Parse<EventLogType>(item.PartitionKey)
            };
        }
    }
}