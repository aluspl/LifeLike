using LifeLike.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeLike.Services.CloudServices
{
    public class QueueService : IQueueService
    {
        private const string NOTIFICATION = "NOTIFICATIONS";

        public IEnumerable<string> ReadMessages(string name)
        {
            return new List<string>();
        }

        public IEnumerable<string> ReadNotifications()
        {
            return ReadMessages(NOTIFICATION);
        }

        public void SendMessage(string message, string name)
        {
        }

        public void SendNotification(string v)
        {
            SendMessage(v, NOTIFICATION);
        }
    }
}
