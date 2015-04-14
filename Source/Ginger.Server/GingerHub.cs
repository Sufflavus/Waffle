using System;

using Microsoft.AspNet.SignalR;


namespace Ginger.Server
{
    public class GingerHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.All.ReceiveMessage(name, message);
        }


        public void UpdateUserState(string name, string user)
        {
            Clients.All.ReceiveUserState(name, user);
        }
    }
}
