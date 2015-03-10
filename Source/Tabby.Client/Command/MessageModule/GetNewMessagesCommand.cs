using System;
using System.Collections.Generic;
using System.Linq;

using Taddy.BusinessLogic.Models;


namespace Tabby.Client.Command.MessageModule
{
    public sealed class GetNewMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            List<Message> messages = MessageProcessor.GetNewMessages(UserId);

            if (messages.Any())
            {
                Logger.Trace("New messages:");
                messages.ForEach(x => Logger.Trace(x.ToString()));
            }
            else
            {
                Logger.Trace("There is not any message");
            }
        }
    }
}
