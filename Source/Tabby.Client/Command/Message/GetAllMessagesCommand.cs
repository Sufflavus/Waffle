using System;
using System.Collections.Generic;
using System.Linq;


namespace Tabby.Client.Command.Message
{
    public sealed class GetAllMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            List<Taddy.BusinessLogic.Models.Message> messages = MessageProcessor.GetAllMessages();

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
