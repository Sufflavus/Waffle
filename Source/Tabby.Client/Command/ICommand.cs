using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    public interface ICommand
    {
        IMessageProcessor MessageProcessor { get; set; }

        string MessageText { get; set; }

        void Execute();
    }
}
