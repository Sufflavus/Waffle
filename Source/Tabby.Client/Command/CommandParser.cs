using System;


namespace Tabby.Client.Command
{
    /// <summary>
    /// A class that converts a string to the command. 
    /// </summary>
    public sealed class CommandParser
    {
        /// <summary>
        /// Parse command.
        /// </summary>
        /// <param name="commandText">A command as a text string.</param>
        /// <returns>New class.</returns>
        public static MessageCommand Parse(string commandText)
        {
            return new SendMessageCommand { MessageText = commandText };
        }
    }
}
