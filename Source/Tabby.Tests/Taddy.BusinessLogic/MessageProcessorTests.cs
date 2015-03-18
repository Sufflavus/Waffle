using System;
using System.Collections.Generic;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using NSubstitute;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;

using Xunit;


namespace Waffle.Tests.Taddy.BusinessLogic
{
    public class MessageProcessorTests
    {
        private readonly IMessageProcessor _messageProcessor;
        private readonly IBijuuServiceClient _serviceClient;


        public MessageProcessorTests()
        {
            _serviceClient = Substitute.For<IBijuuServiceClient>();
            _messageProcessor = new MessageProcessor { ServiceClient = _serviceClient };
        }


        [Fact]
        public void GetAllMessages_ServiceClient_IsCalled()
        {
            _serviceClient.GetAllMessages().Returns(new List<MessageInfo>());

            _messageProcessor.GetAllMessages();

            _serviceClient.Received().GetAllMessages();
        }


        [Fact]
        public void GetNewMessages_ServiceClient_IsCalled()
        {
            Guid userId = Guid.NewGuid();
            _serviceClient.GetNewMessages(userId).Returns(new List<MessageInfo>());

            _messageProcessor.GetNewMessages(userId);

            _serviceClient.Received().GetNewMessages(userId);
        }


        [Fact]
        public void SendMessage_ServiceClient_IsCalled()
        {
            var message = new Message { Text = "text", SenderId = Guid.NewGuid() };
            _serviceClient.SendMessage(message.Text, message.SenderId).Returns(message.Text.Length);

            _messageProcessor.SendMessage(message);

            _serviceClient.Received().SendMessage(message.Text, message.SenderId);
        }
    }
}
