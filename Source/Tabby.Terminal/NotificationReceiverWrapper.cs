using System;

using Ginger.Notifier;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Models;


namespace Tabby.Terminal
{
    public sealed class NotificationReceiverWrapper
    {
        [Dependency]
        public INotificationReceiver NotificationReceiver { get; set; }


        public void Init(Action<Message> onMessageReceive, Action<User> onUserStateChanged)
        {
            NotificationReceiver.SubscribeForReceivingMessage(x => onMessageReceive(NotifierConverter.ToMessage(x)));
            NotificationReceiver.SubscribeForReceivingUserState(x => onUserStateChanged(NotifierConverter.ToUser(x)));
        }
    }
}
