﻿using System;
using System.Collections.Generic;

using NSubstitute;

using Tabby.Terminal.Command.MessageModule;
using Tabby.Terminal.Logger;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;

using Xunit;


namespace Waffle.Tests.Tabby.Terminal
{
    public class GetNewMessagesCommandTests
    {
        [Fact]
        public void Execute_MessageProcessor_IsCalled()
        {
            var messageProcessor = Substitute.For<IMessageProcessor>();
            Guid userId = Guid.NewGuid();
            messageProcessor.GetNewMessages(userId).Returns(new List<Message>());
            var logger = Substitute.For<ILogger>();
            var command = new GetNewMessagesCommand { MessageProcessor = messageProcessor, Logger = logger, UserId = userId };

            command.Execute();

            messageProcessor.Received().GetNewMessages(userId);
        }
    }
}
