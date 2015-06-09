﻿using System;

using Ginger.Notifier;

using NSubstitute;

using Tabby.Terminal;

using Xunit;


namespace Waffle.Tests.Tabby.Terminal
{
    public class NotificationReceiverWrapperTests
    {
        private readonly INotificationReceiver _receiver;
        private readonly NotificationReceiverWrapper _wrapper;


        public NotificationReceiverWrapperTests()
        {
            _receiver = Substitute.For<INotificationReceiver>();
            _wrapper = new NotificationReceiverWrapper { NotificationReceiver = _receiver };
        }


        [Fact]
        public void GetUserId_ReceiverId()
        {
            Guid receiverId = Guid.NewGuid();
            _wrapper.RegisterReceiver(receiverId);

            string result = _wrapper.GetUserId(null);

            Assert.Equal(receiverId.ToString(), result);
        }
    }
}
