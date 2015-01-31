using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command.Message
{
    public abstract class MessageCommand : ICommand
    {
        public IMessageProcessor MessageProcessor { get; set; }

        public string MessageText { get; set; }
        public Guid UserId { get; set; }

        public abstract void Execute();
    }
}
