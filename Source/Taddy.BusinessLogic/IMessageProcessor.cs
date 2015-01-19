using System;
using System.Collections.Generic;


namespace Taddy.BusinessLogic
{
    public interface IMessageProcessor
    {
        List<Message> GetAllMessages();
        int SendMessage(Message message);
    }
}
