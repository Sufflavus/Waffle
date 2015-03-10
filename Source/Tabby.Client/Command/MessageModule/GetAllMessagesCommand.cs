using System;
using System.Collections.Generic;
using System.Linq;

using Taddy.BusinessLogic.Models;


namespace Tabby.Client.Command.MessageModule
{
    public sealed class GetAllMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            List<Message> messages = MessageProcessor.GetAllMessages();

            if (messages.Any())
            {
                Logger.Trace("All messages:");
                messages.ForEach(x => Logger.Trace(x.ToString()));
            }
            else
            {
                Logger.Trace("There is not any message");
            }
        }
    }
}
