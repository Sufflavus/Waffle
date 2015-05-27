using System;

using Tabby.Terminal.Command.MessageModule;


namespace Tabby.Terminal.Command
{
    /// <summary>
    /// A class that converts a string to the command. 
    /// </summary>
    public sealed class CommandParser
    {
        private const char CommandTypeSeparator = ':';


        /// <summary>
        /// Parse command.
        /// </summary>
        /// <param name="commandText">A command as a text string.</param>
        /// <returns>New class.</returns>
        public static MessageCommand Parse(string commandText)
        {
            CommandType commandType = GetCommandType(commandText);

            switch (commandType)
            {
                case CommandType.Send:
                    return CreateSendMessageCommand(commandText);
                case CommandType.SendTo:
                    return CreateSendMessageToUserCommand(commandText);
                case CommandType.GetAll:
                    return Bootstrapper.Resolve<GetAllMessagesCommand>();
                case CommandType.GetNew:
                    return Bootstrapper.Resolve<GetNewMessagesCommand>();
                default:
                    throw new ArgumentException("Invalid command");
            }
        }


        private static SendMessageCommand CreateSendMessageCommand(string commandText)
        {
            int separatorIndex = commandText.IndexOf(CommandTypeSeparator);
            string messageText = commandText.Substring(separatorIndex + 1).Trim();

            if (separatorIndex < 0 || string.IsNullOrEmpty(messageText))
            {
                throw new ArgumentException("Invalid command");
            }

            var command = Bootstrapper.Resolve<SendMessageCommand>();
            command.MessageText = messageText;
            return command;
        }


        private static SendMessageToUserCommand CreateSendMessageToUserCommand(string commandText)
        {
            string[] commandParts = commandText.Trim().ToLower().Split(CommandTypeSeparator);
            string commandData = commandParts[1].Trim();
            int separatorIndex = commandData.IndexOf(' ');
            string recipientName = commandData.Substring(0, separatorIndex).Trim();
            string messageText = commandData.Substring(separatorIndex + 1).Trim();
            
            if (separatorIndex < 0 || string.IsNullOrEmpty(messageText) || string.IsNullOrEmpty(recipientName))
            {
                throw new ArgumentException("Invalid command");
            }

            var command = Bootstrapper.Resolve<SendMessageToUserCommand>();
            command.RecipientName = recipientName;
            command.MessageText = messageText;
            return command;
        }


        private static CommandType GetCommandType(string commandText)
        {
            string[] commandParts = commandText.Trim().ToLower().Split(CommandTypeSeparator);
            if (commandParts.Length < 1)
            {
                throw new ArgumentException("Invalid command");
            }
            string commandType = commandParts[0];

            switch (commandType)
            {
                case "send":
                    return CommandType.Send;
                case "sendto":
                    return CommandType.SendTo;
                case "getall":
                    return CommandType.GetAll;
                case "getnew":
                    return CommandType.GetNew;
                default:
                    throw new ArgumentException("Invalid command");
            }
        }
    }
}
