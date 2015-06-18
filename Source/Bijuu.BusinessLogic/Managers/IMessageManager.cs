using System;
using System.Collections.Generic;

using Bijuu.Contracts;


namespace Bijuu.BusinessLogic.Managers
{
    public interface IMessageManager
    {
        List<MessageInfo> GetAllMessages();
        List<MessageInfo> GetNewMessages(Guid userId);
        int SendMessage(MessageInfo message);
        int SendMessageToUser(MessageInfo message);
    }
}
