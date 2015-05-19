using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR;


namespace Ginger.Server
{
    public class GingerHub : Hub
    {
        private static readonly ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();


        public override Task OnConnected()
        {
            if (Context.User == null)
            {
                return base.OnConnected();
            }

            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            if (Context.User == null)
            {
                return base.OnDisconnected(stopCalled);
            }

            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }


        public override Task OnReconnected()
        {
            if (Context.User == null)
            {
                return base.OnReconnected();
            }

            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }


        public void SendMessage(string receiverId, string message)
        {
            /*foreach (var connectionId in _connections.GetConnections(receiverId))
            {
                Clients.Client(connectionId).ReceiveMessage(message);
            }*/

            //Clients.User(receiverId).ReceiveMessage(message);
            Clients.All.ReceiveMessage(message);
        }


        public void UpdateUserState(string excludeReceiverId, string user)
        {
            /*foreach (var connectionId in _connections.GetConnections(excludeReceiverId))
            {
                Clients.AllExcept(connectionId).ReceiveUserState(user);
            }*/

            //Clients.AllExcept(excludeReceiverId).ReceiveUserState(user);
            Clients.All.ReceiveUserState(user);
        }
    }
}
