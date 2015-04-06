using System;

using Ginger.Notifier.Properties;

using Microsoft.AspNet.SignalR.Client;


namespace Ginger.Notifier
{
    public sealed class NotificationService : INotificationService
    {
        public void SendMessage(string message)
        {
            using (var connection = new HubConnection(Settings.Default.ServiceUrl))
            {
                IHubProxy hub = connection.CreateHubProxy(ServerSettings.GingerHubClassName);
                connection.Start();
                hub.Invoke(ServerSettings.GingerSendMethodName, message).Wait();
            }
        }
    }
}
