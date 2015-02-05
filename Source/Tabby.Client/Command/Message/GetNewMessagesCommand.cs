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

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            if (messages.Any())
            {
                Console.WriteLine("New messages:");
                messages.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("There are no new messages");
            }
            Console.WriteLine();
        }
    }
}
