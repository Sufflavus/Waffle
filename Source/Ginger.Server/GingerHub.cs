using System;

using Microsoft.AspNet.SignalR;


namespace Ginger.Server
{
    public class GingerHub : Hub
    {
        public void SendMessage(string receiverId, string message)
        {
            Clients.User(receiverId).ReceiveMessage(message);
            //Clients.All.ReceiveMessage(message);
        }


        public void UpdateUserState(string excludeReceiverId, string user)
        {
            Clients.AllExcept(excludeReceiverId).ReceiveUserState(user);
            //Clients.All.ReceiveUserState(user);
        }
    }
}
