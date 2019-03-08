using LifeLike.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeLike.CloudService.Queue
{
    public class QueueStorage : IQueueService
    {
        private readonly CloudQueueClient _queueClient;

        public QueueStorage(IConfiguration configuration)
        {
            var storageAccount = CloudStorageAccount.Parse(configuration["BlobStorage"]);
            _queueClient=storageAccount.CreateCloudQueueClient();            
        }
        public CloudQueue GetQueue(string name)
        {
            var cloud =  _queueClient.GetQueueReference(name);
            cloud.CreateIfNotExistsAsync().Wait();
            return cloud;
        }
        public void SendMessage(string message, string name)
        {
            var queue = GetQueue(name);
            queue.AddMessageAsync(new CloudQueueMessage(message)).Wait();
        }
        public IEnumerable<string> ReadMessages(string name)
        {
            var queue = GetQueue(name);
            var messages = queue.GetMessagesAsync(10).Result;
           
            return messages.Select(o => o.AsString);
        }
    }
}
