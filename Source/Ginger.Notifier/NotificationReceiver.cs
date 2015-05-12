using System;

using Ginger.Contracts;
using Ginger.Notifier.Properties;
using Ginger.Server;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;

using Newtonsoft.Json;


namespace Ginger.Notifier
{
    public sealed class NotificationReceiver : INotificationReceiver, IDisposable
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _hub;
        private IDisposable _receivingMessageSubscription;
        private IDisposable _receivingUserStateSubscription;


        public NotificationReceiver()
        {
            _connection = new HubConnection(Settings.Default.ServiceUrl);
            _hub = _connection.CreateHubProxy(ServerSettings.HubClassName);
            _connection.Start().Wait();
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


        public void RegisterReceiver(IUserIdProvider idProvider)
        {
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);
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
    }
}
