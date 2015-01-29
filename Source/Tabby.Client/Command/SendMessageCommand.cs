using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public sealed class SendMessageCommand : MessageCommand
    {
        public override void Execute()
        {
            //TODO: make it testable
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Message message = BusinessLogicConverter.ToMessage(MessageText);
            int result = MessageProcessor.SendMessage(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Сообщение '{0}' отправлено. Кол-во символов в сообщении: {1}", MessageText, result);
            Console.WriteLine();
        }
    }
}
