using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public abstract class MessageCommand : ICommand
    {
        public string MessageText { get; set; }

        public IMessageProcessor MessageProcessor { get; set; }

        public abstract void Execute();
    }
}
