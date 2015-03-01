using System;

using Tabby.Client.Command;
using Tabby.Client.Command.Message;

using Xunit;
using Xunit.Extensions;


namespace Waffle.Tests.Tabby.Client
{
    public class CommandParserTests
    {
        private const string GetAllCommandPrefix = "GetAll";
        private const string GetNewCommandPrefix = "GetNew";
        private const string SendCommandPrefix = "Send:";


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void Parse_BadSendCommandText_Throws(string messageText)
        {
            string commandText = string.Format("{0} {1}", SendCommandPrefix, messageText);

            Exception result = Assert.Throws<ArgumentException>(() => CommandParser.Parse(commandText));

            Assert.IsType(typeof(ArgumentException), result);
            Assert.Equal("Invalid command", result.Message);
        }


        [Theory]
        [InlineData("FakeCommand")]
        [InlineData("Send")]
        [InlineData(" ")]
        [InlineData(":")]
        public void Parse_BagCommand_Throws(string commandText)
        {
            Exception result = Assert.Throws<ArgumentException>(() => CommandParser.Parse(commandText));

            Assert.IsType(typeof(ArgumentException), result);
            Assert.Equal("Invalid command", result.Message);
        }


        [Fact]
        public void Parse_GoodGetAllCommandText_CorrectGetAllMessagesCommand()
        {
            string commandText = GetAllCommandPrefix;

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.IsType(typeof(GetAllMessagesCommand), result);
        }


        [Fact]
        public void Parse_GoodGetNewCommandText_CorrectGetNewMessagesCommand()
        {
            string commandText = GetNewCommandPrefix;

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.IsType(typeof(GetNewMessagesCommand), result);
        }


        [Fact]
        public void Parse_GoodSendCommandText_SendMessageCommand()
        {
            string messageText = "message";
            string commandText = string.Format("{0} {1}", SendCommandPrefix, messageText);

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.Equal(messageText, result.MessageText);
            Assert.IsType(typeof(SendMessageCommand), result);
        }
    }
}
