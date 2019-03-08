using System;
using System.Collections.Generic;
using System.Text;

namespace LifeLike.Shared.Services
{
    public interface IQueueService
    {
        IEnumerable<string> ReadMessages(string name);
        void SendMessage(string message, string name);
        void SendNotification(string v);
        IEnumerable<string> ReadNotifications();

    }
}
