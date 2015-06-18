using System;
using System.Collections.Generic;

using Bijuu.Contracts;


namespace Bijuu.ServiceProvider
{
    public interface IBijuuServiceClient
    {
        List<MessageInfo> GetAllMessages();
        List<MessageInfo> GetNewMessages(Guid userId);
        UserInfo GetUserByName(string userName);
        UserInfo LogIn(string userName);
        void LogOut(Guid userId);
        int SendMessage(string message, Guid senderId);
        int SendMessageToUser(MessageInfo message);
    }
}
