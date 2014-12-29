using System;


namespace Tabby.Client.Command
{
    /// <summary>
    /// Класс, который преобразует строку в команду.
    /// </summary>
    public sealed class CommandParser
    {
        /// <summary>
        /// Распарсить команду.
        /// </summary>
        /// <param name="commandText">Команда в виде текстовой строки.</param>
        /// <returns>Класс-команда.</returns>
        public static MessageCommand Parse(string commandText)
        {
            return new SendMessageCommand { MessageText = commandText };
        }
    }
}
