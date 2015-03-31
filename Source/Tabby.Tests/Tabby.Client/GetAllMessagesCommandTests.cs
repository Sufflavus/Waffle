using System;
using System.Collections.Generic;

using NSubstitute;

using Tabby.Terminal.Command.MessageModule;
using Tabby.Terminal.Logger;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;

using Xunit;


namespace Waffle.Tests.Tabby.Client
{
    public class GetAllMessagesCommandTests
    {
        [Fact]
        public void Execute_MessageProcessor_IsCalled()
        {
            var messageProcessor = Substitute.For<IMessageProcessor>();
            messageProcessor.GetAllMessages().Returns(new List<Message>());
            var logger = Substitute.For<ILogger>();
            var command = new GetAllMessagesCommand { MessageProcessor = messageProcessor, Logger = logger };

            command.Execute();

            messageProcessor.Received().GetAllMessages();
        }
    }
}
