using System;
using System.Collections.Generic;
using System.Linq;


namespace Tabby.Client.Command.Message
{
    public sealed class GetNewMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            List<Taddy.BusinessLogic.Models.Message> messages = MessageProcessor.GetNewMessages(UserId);

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
