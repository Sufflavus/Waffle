using System;

using Ginger.Contracts;
using Ginger.Notifier.Properties;
using Ginger.Server;

using Microsoft.AspNet.SignalR.Client;

using Newtonsoft.Json;


namespace Ginger.Notifier
{
    public sealed class NotificationService : INotificationService
    {
        public void SendMessage(MessageRecord message)
        {
            InvokeServiceMethod(ServerSettings.SendMessageMethodName, message);
        }


        public void UpdateUserState(UserRecord user)
        {
            InvokeServiceMethod(ServerSettings.UpdateUserStateMethodName, user);
        }


        private void InvokeServiceMethod(string methodName, object objectForSend)
        {
            using (var connection = new HubConnection(Settings.Default.ServiceUrl))
            {
                IHubProxy hub = connection.CreateHubProxy(ServerSettings.HubClassName);
                connection.Start();
                string objectForSendJson = JsonConvert.SerializeObject(objectForSend);
                hub.Invoke(methodName, objectForSendJson).Wait();
            }
        }
    }
}
