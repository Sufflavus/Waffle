using System;

using Microsoft.AspNet.SignalR;


namespace Ginger.Server
{
    public class GingerHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.All.SendMessage(name, message);
        }


        public void UpdateUserState(string name, string user)
        {
            Clients.All.UpdateUserState(name, user);
        }
    }
}
