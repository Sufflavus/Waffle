using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public abstract class MessageCommand : ICommand
    {
        public IMessageProcessor MessageProcessor { get; set; }

        public string MessageText { get; set; }

        public abstract void Execute();
    }
}
