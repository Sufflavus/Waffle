using System;


namespace Taddy.BusinessLogic
{
    public class MessageProcessor : IMessageProcessor
    {
        public int SendMessage(Message message)
        {
            return message.Text.Length;
        }
    }
}
