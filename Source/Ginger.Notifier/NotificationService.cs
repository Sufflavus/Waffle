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
        private IDisposable _receivingMessageSubscription;
        private IDisposable _receivingUserStateSubscription;

        public NotificationService()
        {
            _connection = new HubConnection(Settings.Default.ServiceUrl);
            _connection.Start();
            _hub = _connection.CreateHubProxy(ServerSettings.HubClassName);
        }


        public void Dispose()
        {
            if (_receivingMessageSubscription != null)
            {
                _receivingMessageSubscription.Dispose();
            }

            if (_receivingUserStateSubscription != null)
            {
                _receivingUserStateSubscription.Dispose();
            }

            _connection.Dispose();
        }


        public void SubscribeForReceivingMessage(Action<MessageRecord> onMessageReceive)
        {
            _receivingMessageSubscription = _hub.On<string>(ServerSettings.ReceiveMessageMethodName, x =>
            {
                var record = JsonConvert.DeserializeObject<MessageRecord>(x);
                onMessageReceive(record);
            });
        }


        public void SubscribeForReceivingUserState(Action<UserRecord> onUserStateReceive)
        {
            _receivingUserStateSubscription = _hub.On<string>(ServerSettings.ReceiveUserStateMethodName, x =>
            {
                var record = JsonConvert.DeserializeObject<UserRecord>(x);
                onUserStateReceive(record);
            });
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
