using System;

using Bijuu.Contracts;

using Ginger.Notifier;

using Microsoft.Practices.Unity;


namespace Bijuu.Service
{
    public sealed class Notifier : INotifier
    {
        [Dependency]
        public INotificationService NotificationService { get; set; }


        public void NewMessageNotify(MessageInfo message)
        {
            NotificationService.SendMessage(message.Text);
        }
    }
}
