﻿using System;
using System.Collections.Generic;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic;

using Xunit;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    public class MessageProcessorTests : IUseFixture<MockRepository>
    {
        private MockRepository _repository;

        public void SetFixture(MockRepository data)
        {
            _repository = new MockRepository();
        }

        [Fact]
        public void GetAll_CorrectResult()
        {
            IMessageProcessor messageProcessor = new MessageProcessor(_repository);
            var message1 = new MessageEntity { Id = Guid.NewGuid(), Text = "text1", CreateDate = DateTime.Now };
            var message2 = new MessageEntity { Id = Guid.NewGuid(), Text = "text2", CreateDate = DateTime.Now };
            _repository.AddOrUpdate(message1);
            _repository.AddOrUpdate(message2);
            int itemsCount = _repository.Storage.Count;

            List<Message> result = messageProcessor.GetAllMessages();

            Assert.Equal(itemsCount, result.Count);
            Assert.Equal(message1.Text, result[0].Text);
            Assert.Equal(message2.Text, result[1].Text);
        }


        [Fact]
        public void SendMessage_GoodInput_AddInRepository()
        {
            IMessageProcessor messageProcessor = new MessageProcessor(_repository);
            var message = new Message { Text = "text" };

            int result = messageProcessor.SendMessage(message);

            Assert.Equal(message.Text.Length, result);
            BaseEntity actual = _repository.Storage[0];
            Assert.IsType<MessageEntity>(actual);
            Assert.Equal(message.Text, ((MessageEntity)actual).Text);
        }
    }
}
