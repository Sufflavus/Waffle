using System;


namespace Taddy.BusinessLogic
{
    public interface IMessageProcessor
    {
        int SendMessage(Message message);
    }
}
