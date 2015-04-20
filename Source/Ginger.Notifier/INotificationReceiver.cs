using System;

using Ginger.Contracts;


namespace Ginger.Notifier
{
    public interface INotificationReceiver
    {
        void SubscribeForReceivingMessage(Action<MessageRecord> onMessageReceive);

        void SubscribeForReceivingUserState(Action<UserRecord> onUserStateReceive);
    }
}
