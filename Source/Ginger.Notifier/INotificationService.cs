using System;


namespace Ginger.Notifier
{
    public interface INotificationService
    {
        void SendMessage(string message);
    }
}
