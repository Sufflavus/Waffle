using System;

using Ginger.Contracts;


namespace Ginger.Notifier
{
    public interface INotificationService
    {
        MessageRecord ReceiveMessage();

        UserRecord ReceiveUserState();

        void SendMessage(MessageRecord message);

        void UpdateUserState(UserRecord user);
    }
}
