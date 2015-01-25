using System;

using Tabby.Client.Command;

using Xunit;
using Xunit.Extensions;


namespace Tabby.Tests.Tabby.Client
{
    public class CommandParserTests
    {
        private const string GetAllCommandPrefix = "GetAll";
        private const string GetNewCommandPrefix = "GetNew";
        private const string SendCommandPrefix = "Send:";


        [Fact]
        public void Parse_GetAllMessagesCommand_CorrectCommand()
        {
            string commandText = GetAllCommandPrefix;

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.IsType(typeof(GetAllMessagesCommand), result);
        }


        [Fact]
        public void Parse_GetNewCommand_CorrectCommand()
        {
            string commandText = GetNewCommandPrefix;

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.IsType(typeof(GetNewMessagesCommand), result);
        }


        [Theory]
        [InlineData("FakeCommand")]
        [InlineData("Send")]
        [InlineData(" ")]
        [InlineData(":")]
        public void Parse_IncorrectCommand_ThrowsException(string commandText)
        {
            Exception result = Assert.Throws<ArgumentException>(() => CommandParser.Parse(commandText));

            Assert.IsType(typeof(ArgumentException), result);
            Assert.Equal("Invalid command", result.Message);
        }


        [Fact]
        public void Parse_SendMessageCommand_CorrectCommand()
        {
            string messageText = "message";
            string commandText = string.Format("{0} {1}", SendCommandPrefix, messageText);

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.Equal(messageText, result.MessageText);
            Assert.IsType(typeof(SendMessageCommand), result);
        }


        [Fact]
        public void Parse_SendMessageCommand_EmptyMessage_ThrowsException()
        {
            string messageText = "";
            string commandText = string.Format("{0} {1}", SendCommandPrefix, messageText);

            Exception result = Assert.Throws<ArgumentException>(() => CommandParser.Parse(commandText));

            Assert.IsType(typeof(ArgumentException), result);
            Assert.Equal("Invalid command", result.Message);
        }
    }
}
