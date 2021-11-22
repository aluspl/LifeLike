using System.Collections.Generic;

namespace LifeLike.Services.Commons.Interfaces
{
    public interface IQueueService
    {
        IEnumerable<string> ReadMessages(string name);
        void SendMessage(string message, string name);
        void SendNotification(string v);
        IEnumerable<string> ReadNotifications();

    }
}
