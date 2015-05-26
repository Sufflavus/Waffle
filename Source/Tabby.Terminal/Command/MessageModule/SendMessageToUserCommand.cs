using System;

using Microsoft.Practices.Unity;

using Tabby.Terminal.Converters;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Terminal.Command.MessageModule
{
    public sealed class SendMessageToUserCommand : MessageCommand
    {
        public string RecipientName { get; set; }

        [Dependency]
        public IUserProcessor UserProcessor { get; set; }


        public override void Execute()
        {
            User Recipient = UserProcessor.GetUserByName(RecipientName);
            Message message = BusinessLogicConverter.ToMessage(MessageText);
            message.SenderId = UserId;
            message.RecipientId = Recipient.Id;
            int result = MessageProcessor.SendMessage(message);
            Logger.Trace(string.Format("The message '{0}' has been send. Message length: {1}", MessageText, result));
        }
    }
}
