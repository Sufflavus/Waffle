using System;

using Ginger.Notifier;

using Microsoft.Practices.Unity;

using Tabby.Terminal.Converters;

using Taddy.BusinessLogic.Models;


namespace Tabby.Terminal
{
    public sealed class NotificationReceiverWrapper
    {
        [Dependency]
        public INotificationReceiver NotificationReceiver { get; set; }


        public void SubscribeForReceivingMessage(Action<Message> onMessageReceive)
        {
            NotificationReceiver.SubscribeForReceivingMessage(x => onMessageReceive(NotifierConverter.ToMessage(x)));
        }


        public void SubscribeForReceivingUserState(Action<User> onUserStateChanged)
        {
            NotificationReceiver.SubscribeForReceivingUserState(x => onUserStateChanged(NotifierConverter.ToUser(x)));
        }
    }
}
