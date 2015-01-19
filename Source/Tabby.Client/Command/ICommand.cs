using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    /// <summary>
    /// The command to execute.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute command.
        /// </summary>
        void Execute();

        string MessageText { get; set; }

        IMessageProcessor MessageProcessor { get; set; }
    }
}
