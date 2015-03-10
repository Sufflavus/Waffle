using System;

using Microsoft.Practices.Unity;

using Tabby.Client.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Command.MessageModule
{
    public abstract class MessageCommand : ICommand
    {
        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public IMessageProcessor MessageProcessor { get; set; }

        public string MessageText { get; set; }
        public Guid UserId { get; set; }

        public abstract void Execute();
    }
}
