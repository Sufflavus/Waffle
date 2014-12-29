using System;

using Taddy.BusinessLogic;


namespace Tabby.Client.Command
{
    /// <summary>
    /// Команда для выполнения.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить команду.
        /// </summary>
        void Execute();

        string MessageText { get; set; }

        IMessageProcessor MessageProcessor { get; set; }
    }
}
