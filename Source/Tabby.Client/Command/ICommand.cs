using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    /// <summary>
    /// The command to execute.
    /// </summary>
    public interface ICommand
    {
        IMessageProcessor MessageProcessor { get; set; }
        string MessageText { get; set; }


        /// <summary>
        /// Execute command.
        /// </summary>
        void Execute();
    }
}
