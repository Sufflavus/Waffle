using System;

using Ginger.Contracts;
using Ginger.Notifier.Properties;
using Ginger.Server;

using Microsoft.AspNet.SignalR.Client;

using Newtonsoft.Json;


namespace Ginger.Notifier
{
    public sealed class NotificationSender : INotificationSender, IDisposable
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _hub;


        public NotificationSender()
        {
            _connection = new HubConnection(Settings.Default.ServiceUrl);
            _hub = _connection.CreateHubProxy(ServerSettings.HubClassName);
            _connection.Start().Wait();
        }


        public void Dispose()
        {
            _connection.Dispose();
        }


        public void NotifySendMessage(MessageRecord message)
        {
            string objectForSendJson = JsonConvert.SerializeObject(message);
            _hub.Invoke(ServerSettings.SendMessageMethodName, message.RecipientId.Value.ToString(), objectForSendJson).Wait();
            //InvokeServiceMethod(ServerSettings.SendMessageMethodName, message.RecipientId.Value, message);
        }


        public void NotifyUpdateUserState(UserRecord user)
        {
            string objectForSendJson = JsonConvert.SerializeObject(user);
            _hub.Invoke(ServerSettings.UpdateUserStateMethodName, user.Id.ToString(), objectForSendJson).Wait();
            //InvokeServiceMethod(ServerSettings.UpdateUserStateMethodName, user);
        }


        private void InvokeServiceMethod(string methodName, Guid receiverId, object objectForSend)
        {
            string objectForSendJson = JsonConvert.SerializeObject(objectForSend);
            _hub.Invoke(methodName, receiverId.ToString(), objectForSendJson).Wait();
        }
    }
}
