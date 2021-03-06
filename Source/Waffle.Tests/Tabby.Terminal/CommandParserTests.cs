﻿using System;

using Tabby.Terminal.Command;
using Tabby.Terminal.Command.MessageModule;

using Xunit;
using Xunit.Extensions;


namespace Waffle.Tests.Tabby.Terminal
{
    public class CommandParserTests
    {
        private const string GetAllCommandPrefix = "GetAll";
        private const string GetNewCommandPrefix = "GetNew";
        private const string SendCommandPrefix = "Send:";
        private const string SendToCommandPrefix = "SendTo:";


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
        [InlineData(";")]
        [InlineData("")]
        [InlineData(null)]
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


        [Fact]
        public void Parse_GoodSendMessageToUserCommandText_SendMessageToUserCommand()
        {
            string userName = "BlackHat";
            string messageText = "Message text";
            string commandText = string.Format("{0} {1} {2}", SendToCommandPrefix, userName, messageText);

            MessageCommand result = CommandParser.Parse(commandText);

            Assert.Equal(messageText, result.MessageText);
            Assert.IsType(typeof(SendMessageToUserCommand), result);
            Assert.Equal(userName, ((SendMessageToUserCommand)result).RecipientName);
        }
    }
}
