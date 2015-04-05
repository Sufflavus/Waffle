using System;

using Microsoft.AspNet.SignalR;


namespace Ginger.Server
{
    public class GingerHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.SendMessage(name, message);
        }
    }
}
