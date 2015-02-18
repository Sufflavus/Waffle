using System;


namespace Tabby.Client.Command.Message
{
    public sealed class SendMessageCommand : MessageCommand
    {
        public override void Execute()
        {
            Taddy.BusinessLogic.Models.Message message = BusinessLogicConverter.ToMessage(MessageText);
            message.SenderId = UserId;
            int result = MessageProcessor.SendMessage(message);
            Logger.Trace(string.Format("The message '{0}' has been send. Message length: {1}", MessageText, result));
        }
    }
}
