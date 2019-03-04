using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace LifeLike.CloudService.TableStorage
{
    internal class LogEntity : TableEntity
    {
        public string Id { get; set; }
        public EventLogType Type { get; set; }
        public string Messages { get; set; }
        public string StackTrace { get; set; }
        public DateTime EventTime { get; set; }

        internal static LogEntity Convert(Log item)
        {
            return new LogEntity
            {
                Messages = item.Messages,
                StackTrace = item.StackTrace,
                RowKey =  Guid.NewGuid().ToString(),
                PartitionKey = item.Type.ToString(),
                EventTime = item.EventTime,
                Type = item.Type            
            };
        }
        internal static Log Convert(LogEntity item)
        {
            return new Log
            {
                Messages = item.Messages,
                StackTrace = item.StackTrace,
                RowKey = item.RowKey,
                PartitionKey = item.PartitionKey,
                EventTime = item.EventTime,
                Type = item.Type
            };
        }
    }
}