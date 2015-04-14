using System;

using Ginger.Contracts;
using Ginger.Notifier.Properties;
using Ginger.Server;

using Microsoft.AspNet.SignalR.Client;

using Newtonsoft.Json;


namespace Ginger.Notifier
{
    public sealed class NotificationService : INotificationService, IDisposable
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _hub;


        public NotificationService()
        {
            _connection = new HubConnection(Settings.Default.ServiceUrl);
            _connection.Start();
            _hub = _connection.CreateHubProxy(ServerSettings.HubClassName);
        }


        public void Dispose()
        {
            _connection.Dispose();
        }


        public MessageRecord ReceiveMessage()
        {
            //_hub.On(ServerSettings.ReceiveMessageMethodName, x => Console.WriteLine(x));
            throw new NotImplementedException();
        }


        public UserRecord ReceiveUserState()
        {
            //_hub.On(ServerSettings.ReceiveUserStateMethodName, x => Console.WriteLine(x));
            throw new NotImplementedException();
        }


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
            string objectForSendJson = JsonConvert.SerializeObject(objectForSend);
            _hub.Invoke(methodName, objectForSendJson).Wait();
        }
    }
}
