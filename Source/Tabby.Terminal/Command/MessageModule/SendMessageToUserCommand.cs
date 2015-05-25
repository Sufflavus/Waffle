﻿using System;

using Tabby.Terminal.Converters;

using Taddy.BusinessLogic.Models;


namespace Tabby.Terminal.Command.MessageModule
{
    public sealed class SendMessageToUserCommand : MessageCommand
    {
        public string RecipientName { get; set; }

        public override void Execute()
        {
            Message message = BusinessLogicConverter.ToMessage(MessageText);
            message.SenderId = UserId;
            int result = MessageProcessor.SendMessage(message);
            Logger.Trace(string.Format("The message '{0}' has been send. Message length: {1}", MessageText, result));
        }
    }
}
