﻿using System;

using Ginger.Notifier;

using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic
{
    public sealed class NotificationReceiverWrapper
    {
        private Guid _receiverId;

        [Dependency]
        public INotificationReceiver NotificationReceiver { get; set; }


        public void RegisterReceiver(Guid receiverId)
        {
            _receiverId = receiverId;
            //NotificationReceiver.RegisterReceiver(this);
        }


        public void SubscribeForReceivingMessage(Action<Message> onMessageReceive)
        {
            NotificationReceiver.SubscribeForReceivingMessage(x => onMessageReceive(NotifierConverter.ToMessage(x)));
        }


        public void SubscribeForReceivingUserState(Action<User> onUserStateChanged)
        {
            NotificationReceiver.SubscribeForReceivingUserState(x => onUserStateChanged(NotifierConverter.ToUser(x)));
        }


        public string GetUserId(IRequest request)
        {
            return _receiverId.ToString();
        }
    }
}
