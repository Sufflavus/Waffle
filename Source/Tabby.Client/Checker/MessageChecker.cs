using System;
using System.Collections.Generic;
using System.Linq;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Checker
{
    public class MessageChecker
    {
        private readonly IMessageProcessor _messageProcessor;
        private readonly Guid _userId;


        public MessageChecker(IMessageProcessor messageProcessor, Guid userId)
        {
            _messageProcessor = messageProcessor;
            _userId = userId;
        }


        public void GetNewMessages(Object stateInfo)
        {
            List<Message> messages = _messageProcessor.GetNewMessages(_userId);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            if (messages.Any())
            {
                Console.WriteLine("New messages:");
                messages.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("There are no new messages");
            }
            Console.WriteLine();
        }
    }
}
