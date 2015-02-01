using System;
using System.Collections.Generic;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic;

using Xunit;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    public class MessageProcessorTests : IUseFixture<MockMessageRepository>
    {
        private IMessageProcessor _messageProcessor;
        private MockMessageRepository _repository;


        [Fact]
        public void GetAll_CorrectResult()
        {
            var user = new UserEntity { Id = Guid.NewGuid(), Name = "user" };
            var message1 = new MessageEntity
            {
                Id = Guid.NewGuid(), 
                Text = "text1", 
                CreateDate = DateTime.Now,
                UserId = user.Id,
                User = user
            };
            var message2 = new MessageEntity
            {
                Id = Guid.NewGuid(), 
                Text = "text2", 
                CreateDate = DateTime.Now,
                UserId = user.Id,
                User = user
            };
            _repository.AddOrUpdate(message1);
            _repository.AddOrUpdate(message2);
            int itemsCount = _repository.Storage.Count;

            List<Message> result = _messageProcessor.GetAllMessages();

            Assert.Equal(itemsCount, result.Count);
            Assert.Equal(message1.Text, result[0].Text);
            Assert.Equal(message2.Text, result[1].Text);
        }


        [Fact]
        public void SendMessage_GoodInput_AddedInRepository()
        {
            var message = new Message { Text = "text" };

            int result = _messageProcessor.SendMessage(message);

            Assert.Equal(message.Text.Length, result);
            BaseEntity actual = _repository.Storage[0];
            Assert.IsType<MessageEntity>(actual);
            Assert.Equal(message.Text, ((MessageEntity)actual).Text);
        }


        public void SetFixture(MockMessageRepository data)
        {
            _repository = new MockMessageRepository();
            _messageProcessor = new MessageProcessor(_repository);
        }
    }
}
