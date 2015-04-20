using System;

using Microsoft.AspNet.SignalR;


namespace Ginger.Server
{
    public class GingerHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.ReceiveMessage(message);
        }


        public void UpdateUserState(string user)
        {
            Clients.All.ReceiveUserState(user);
        }
    }
}
