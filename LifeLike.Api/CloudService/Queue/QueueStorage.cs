using LifeLike.Shared.Structures;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Collections.Generic;
using System.Linq;

namespace LifeLike.CloudService.Queue
{
    public class QueueService : IQueueService
    {
        private readonly CloudQueueClient _queueClient;
        private const string NOTIFICATION= "notifications";

        public QueueService(IConfiguration configuration)
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

        public void SendNotification(string v)
        {
            SendMessage(v, NOTIFICATION);
        }

        public IEnumerable<string> ReadNotifications()
        {
           return ReadMessages(NOTIFICATION);
        }
    }
}
