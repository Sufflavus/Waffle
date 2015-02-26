using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Client.Logger;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Checker
{
    public class MessageChecker
    {
        private readonly Guid _userId;


        public MessageChecker(Guid userId)
        {
            _userId = userId;
        }


        public ILogger Logger { get; set; }

        public IMessageProcessor MessageProcessor { get; set; }


        public void GetNewMessages(Object stateInfo)
        {
            List<Message> messages = MessageProcessor.GetNewMessages(_userId);
            if (messages.Any())
            {
                Logger.Trace("New messages:");
                messages.ForEach(x => Logger.Trace(x.ToString()));
            }
            else
            {
                Logger.Trace("There are no new messages");
            }
        }
    }
}
