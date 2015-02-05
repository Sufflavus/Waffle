using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Models;

using Xunit;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    public class MessageProcessorTests
    {
        private readonly IMessageProcessor _messageProcessor;
        private readonly MockMessageRepository _messageRepository;
        private readonly MockUserRepository _userRepository;


        public MessageProcessorTests()
        {
            _messageRepository = new MockMessageRepository();
            _userRepository = new MockUserRepository();
            _messageProcessor = new MessageProcessor(_messageRepository, _userRepository);
        }


        [Fact]
        public void GetAllMessages_CorrectResult()
        {
            var user = new UserEntity { Id = Guid.NewGuid(), Name = "user" };
            var message1 = new MessageEntity
            {
                Id = Guid.NewGuid(),
                Text = "text1",
                CreateDate = DateTime.Now,
                SenderId = user.Id,
                Sender = user
            };
            var message2 = new MessageEntity
            {
                Id = Guid.NewGuid(),
                Text = "text2",
                CreateDate = DateTime.Now,
                SenderId = user.Id,
                Sender = user
            };
            _messageRepository.AddOrUpdate(message1);
            _messageRepository.AddOrUpdate(message2);
            int itemsCount = _messageRepository.Storage.Count;

            List<Message> result = _messageProcessor.GetAllMessages();

            Assert.Equal(itemsCount, result.Count);
            Assert.Equal(message1.Text, result[0].Text);
            Assert.Equal(message1.SenderId, result[0].SenderId);
            Assert.Equal(message2.Text, result[1].Text);
            Assert.Equal(message2.SenderId, result[1].SenderId);
        }


        [Fact]
        public void GetNewMessages_CorrectResult()
        {
            var user1 = new UserEntity { Id = Guid.NewGuid(), Name = "user" };
            var user2 = new UserEntity { Id = Guid.NewGuid(), Name = "user" };
            var message1 = new MessageEntity
            {
                Id = Guid.NewGuid(),
                Text = "text1",
                CreateDate = DateTime.Now,
                SenderId = user1.Id,
                Sender = user1,
                RecipientId = user2.Id,
                Recipient = user2,
                DeliveryDate = null
            };
            var message2 = new MessageEntity
            {
                Id = Guid.NewGuid(),
                Text = "text2",
                CreateDate = DateTime.Now,
                SenderId = user2.Id,
                Sender = user2,
                RecipientId = user1.Id,
                Recipient = user1,
                DeliveryDate = null
            };
            var message3 = new MessageEntity
            {
                Id = Guid.NewGuid(),
                Text = "text3",
                CreateDate = DateTime.Now,
                SenderId = user2.Id,
                Sender = user2,
                RecipientId = user1.Id,
                Recipient = user1,
                DeliveryDate = DateTime.Now
            };
            _messageRepository.AddOrUpdate(message1);
            _messageRepository.AddOrUpdate(message2);
            _messageRepository.AddOrUpdate(message3);

            List<Message> result = _messageProcessor.GetNewMessages(user1.Id);

            Assert.Equal(1, result.Count);
            Assert.Equal(message2.Text, result[0].Text);
            Assert.Equal(message2.SenderId, result[0].SenderId);
            MessageEntity actual = _messageRepository.Storage.First(x => x.Id == message2.Id);
            Assert.NotNull(actual.DeliveryDate);
        }


        [Fact]
        public void SendMessage_GoodInput_AddedInRepository()
        {
            var user1 = new UserEntity { Id = Guid.NewGuid() };
            var user2 = new UserEntity { Id = Guid.NewGuid() };
            var user3 = new UserEntity { Id = Guid.NewGuid() };
            _userRepository.AddOrUpdate(user1);
            _userRepository.AddOrUpdate(user2);
            _userRepository.AddOrUpdate(user3);
            var message = new Message { Text = "text", SenderId = user1.Id };
            List<UserEntity> recipients = _userRepository.Storage.Where(x => x.Id != message.SenderId).ToList();
            int messagesCount = _messageRepository.Storage.Count;

            _messageProcessor.SendMessage(message);

            Assert.Equal(messagesCount + recipients.Count, _messageRepository.Storage.Count);
            recipients.ForEach(x =>
            {
                MessageEntity actual = _messageRepository.Storage.First(y => y.RecipientId == x.Id);
                Assert.IsType<MessageEntity>(actual);
                Assert.NotEqual(actual.RecipientId, message.SenderId);
            });
        }
    }
}
