using System;
using System.Collections.Generic;


namespace Taddy.BusinessLogic
{
    public interface IMessageProcessor
    {
        List<Message> GetAllMessages();
        List<Message> GetNewMessages();
        int SendMessage(Message message);
    }
}
