using System;

using Tabby.Client.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Command.Message
{
    public abstract class MessageCommand : ICommand
    {
        public ILogger Logger { get; set; }
        public IMessageProcessor MessageProcessor { get; set; }

        public string MessageText { get; set; }
        public Guid UserId { get; set; }

        public abstract void Execute();
    }
}
