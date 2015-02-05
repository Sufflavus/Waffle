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

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            if (messages.Any())
            {
                Console.WriteLine("All messages:");
                messages.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("There is not any message");
            }
            Console.WriteLine();
        }
    }
}
