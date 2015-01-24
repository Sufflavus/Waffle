using System;
using System.Collections.Generic;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public sealed class GetNewMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            Console.WriteLine();
            List<Message> messages = MessageProcessor.GetNewMessages();
            Console.WriteLine();
            Console.WriteLine("New messages:");
            messages.ForEach(x => Console.WriteLine(x));
        }
    }
}
