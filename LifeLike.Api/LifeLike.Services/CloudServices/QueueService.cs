using LifeLike.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeLike.Services.CloudServices
{
    public class QueueService : IQueueService
    {
        public IEnumerable<string> ReadMessages(string name)
        {
            return new List<string>();
        }

        public void SendMessage(string message, string name)
        {
        }
    }
}
