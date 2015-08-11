using System;

using Ginger.Contracts;
using Ginger.Notifier;


namespace Waffle.FitNesseTests
{
    public sealed class MockNotificationSender : INotificationSender
    {
        public void NotifySendMessage(MessageRecord message)
        {
        }


        public void NotifyUpdateUserState(UserRecord user)
        {
        }
    }
}
