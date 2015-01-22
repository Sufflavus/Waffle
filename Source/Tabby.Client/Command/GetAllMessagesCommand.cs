using System;
using System.Collections.Generic;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public sealed class GetAllMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            Console.WriteLine();
            List<Message> messages = MessageProcessor.GetAllMessages();
            Console.WriteLine();
            Console.WriteLine("All messages:");
            messages.ForEach(x => Console.WriteLine(x));
        }
    }
}
