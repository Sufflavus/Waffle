using System;

using Ginger.Contracts;


namespace Ginger.Notifier
{
    public interface INotificationSender
    {
        void NotifySendMessage(MessageRecord message);

        void NotifyUpdateUserState(UserRecord user);
    }
}
