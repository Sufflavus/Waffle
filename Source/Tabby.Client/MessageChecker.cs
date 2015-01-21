using System;
using System.Collections.Generic;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    public class MessageChecker
    {
        private readonly IMessageProcessor _messageProcessor;


        public MessageChecker(IMessageProcessor messageProcessor)
        {
            _messageProcessor = messageProcessor;
        }


        public void GetMessages(Object stateInfo)
        {
            List<Message> messages = _messageProcessor.GetAllMessages();
            messages.ForEach(x => Console.WriteLine(x));
        }
    }
}
