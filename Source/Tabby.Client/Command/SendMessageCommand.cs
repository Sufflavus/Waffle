using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public sealed class SendMessageCommand : MessageCommand
    {
        public override void Execute()
        {
            Message message = BusinessLogicAdapter.CreateMessage(MessageText);
            int result = MessageProcessor.SendMessage(message);
            Console.WriteLine("Сообщение '{0}' отправлено. Кол-во символов в сообщении: {1}", MessageText, result);
        }
    }
}
