using System;

using Tabby.Client.Command;

using Xunit;


namespace Tabby.Tests.Tabby.Client
{
    public class CommandParserTests
    {
        [Fact]
        public void Parse_SendMessageCommand_CorrectCommandText()
        {
            string commandText = "message";

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.Equal(commandText, result.MessageText);
        }


        [Fact]
        public void Parse_SendMessageCommand_CorrectCommandType()
        {
            string commandText = "message";

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.IsType(typeof(SendMessageCommand), result);
        }
    }
}
