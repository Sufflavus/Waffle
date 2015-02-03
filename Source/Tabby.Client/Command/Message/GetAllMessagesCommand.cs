using System;
using System.Collections.Generic;


namespace Tabby.Client.Command.Message
{
    public sealed class GetAllMessagesCommand : MessageCommand
    {
        public override void Execute()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            List<Taddy.BusinessLogic.Models.Message> messages = MessageProcessor.GetAllMessages();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("All messages:");
            messages.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
        }
    }
}
