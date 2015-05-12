using System;

using Ginger.Contracts;

using Microsoft.AspNet.SignalR;


namespace Ginger.Notifier
{
    public interface INotificationSender
    {
        void NotifySendMessage(MessageRecord message);

        void NotifyUpdateUserState(UserRecord user);
    }
}
