using System;

using Ginger.Contracts;


namespace Ginger.Notifier
{
    public interface INotificationService
    {
        void SubscribeForReceivingMessage(Action<MessageRecord> onMessageReceive);

        void SubscribeForReceivingUserState(Action<UserRecord> onUserStateReceive);
        
        void SendMessage(MessageRecord message);

        void UpdateUserState(UserRecord user);
    }
}
