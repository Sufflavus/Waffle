using System;
using System.Collections.Generic;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic
{
    public interface IMessageProcessor
    {
        List<Message> GetAllMessages();
        List<Message> GetNewMessages(Guid userId);
        int SendMessage(Message message);
    }
}
