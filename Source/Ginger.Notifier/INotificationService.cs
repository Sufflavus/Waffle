using System;

using Ginger.Contracts;


namespace Ginger.Notifier
{
    public interface INotificationService
    {
        void SendMessage(MessageRecord message);

        void UpdateUserState(UserRecord user);
    }
}
