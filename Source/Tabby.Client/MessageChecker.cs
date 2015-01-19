using System;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    public class MessageChecker
    {
        private IMessageProcessor _messageProcessor;


        public MessageChecker(IMessageProcessor messageProcessor)
        {
            _messageProcessor = messageProcessor;
        }


        public void GetMessages(Object stateInfo)
        {
            Console.WriteLine("GetMessages");
        }
    }
}
