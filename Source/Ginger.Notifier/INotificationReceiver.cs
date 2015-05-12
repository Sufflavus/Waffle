using System;

using Ginger.Contracts;

using Microsoft.AspNet.SignalR;


namespace Ginger.Notifier
{
    public interface INotificationReceiver
    {
        void RegisterReceiver(IUserIdProvider idProvider);

        void SubscribeForReceivingMessage(Action<MessageRecord> onMessageReceive);

        void SubscribeForReceivingUserState(Action<UserRecord> onUserStateReceive);
    }
}
