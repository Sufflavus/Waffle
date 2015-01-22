using System;
using System.Collections.Generic;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public sealed class GetNewMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            Console.WriteLine("New messages:");
            List<Message> messages = MessageProcessor.GetNewMessages();
            messages.ForEach(x => Console.WriteLine(x));
        }
    }
}
