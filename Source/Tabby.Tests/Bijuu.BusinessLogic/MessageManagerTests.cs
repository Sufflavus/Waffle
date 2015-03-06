using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Contracts;

using NSubstitute;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;

using Xunit;


namespace Waffle.Tests.Bijuu.BusinessLogic
{
    public class MessageManagerTests
    {
        public void GetAllMessages_CorrectResult()
        {
            MockUserRepository userRepository = InitMockUserRepository();
            MockMessageRepository messageRepository = InitMockMessageRepository(userRepository);
            IMessageManager messageManager = new MessageManager(messageRepository, userRepository);
            List<MessageEntity> messages = messageRepository.Storage;
            int itemsCount = messageRepository.Storage.Count;

            List<MessageInfo> result = messageManager.GetAllMessages();

            Assert.Equal(itemsCount, result.Count);
            Assert.Equal(messages[0].Text, result[0].Text);
            Assert.Equal(messages[0].SenderId, result[0].SenderId);
            Assert.Equal(messages[1].Text, result[1].Text);
            Assert.Equal(messages[1].SenderId, result[1].SenderId);
        }


        [Fact]
        public void GetAllMessages_RepositoryCalled()
        {
            var userRepository = Substitute.For<IUserRepository>();
            var messageRepository = Substitute.For<IMessageRepository>();
            messageRepository.GetAll().Returns(new List<MessageEntity>());
            IMessageManager manager = new MessageManager(messageRepository, userRepository);

            manager.GetAllMessages();

            messageRepository.Received().GetAll();
        }


        [Fact]
        public void GetNewMessages_CorrectResult()
        {
            MockUserRepository userRepository = InitMockUserRepository();
            MockMessageRepository messageRepository = InitMockMessageRepository(userRepository);
            IMessageManager messageManager = new MessageManager(messageRepository, userRepository);
            List<MessageEntity> messages = messageRepository.Storage;
            List<UserEntity> users = userRepository.Storage;

            List<MessageInfo> result = messageManager.GetNewMessages(users[0].Id);

            Assert.Equal(1, result.Count);
            Assert.Equal(messages[2].Text, result[0].Text);
            Assert.Equal(messages[2].SenderId, result[0].SenderId);
            MessageEntity actual = messageRepository.Storage.First(x => x.Id == messages[2].Id);
            Assert.True(actual.IsDelivered);
        }


        [Fact]
        public void SendMessage_GoodInput_AddedInRepositoryForAllRecipients()
        {
            MockUserRepository userRepository = InitMockUserRepository();
            MockMessageRepository messageRepository = InitMockMessageRepository(userRepository);
            IMessageManager messageManager = new MessageManager(messageRepository, userRepository);
            List<UserEntity> users = userRepository.Storage;

            var newMessage = new MessageInfo { Text = "text", SenderId = users[0].Id };
            List<UserEntity> recipients = userRepository.Storage.Where(x => x.Id != newMessage.SenderId).ToList();
            int messagesCount = messageRepository.Storage.Count;

            messageManager.SendMessage(newMessage);

            Assert.Equal(messagesCount + recipients.Count, messageRepository.Storage.Count);
            recipients.ForEach(x =>
            {
                MessageEntity actual = messageRepository.Storage.First(y => y.RecipientId == x.Id);
                Assert.IsType<MessageEntity>(actual);
                Assert.NotEqual(actual.RecipientId, newMessage.SenderId);
                Assert.False(actual.IsDelivered);
            });
        }


        private List<MessageEntity> CreateMessages(MockUserRepository userRepository)
        {
            List<UserEntity> users = userRepository.Storage;
            UserEntity user1 = users[0];
            UserEntity user2 = users[1];

            var message1 = new MessageEntity
            {
                Id = Guid.NewGuid(),
                Text = "text1",
                CreateDate = DateTime.Now,
                SenderId = user1.Id,
                Sender = user1,
                RecipientId = user2.Id,
                Recipient = user2,
                IsDelivered = false
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
                IsDelivered = false
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
                IsDelivered = true
            };
            return new List<MessageEntity> { message1, message2, message3 };
        }


        private List<UserEntity> CreateUsers()
        {
            var user1 = new UserEntity { Id = Guid.NewGuid(), Name = "user1" };
            var user2 = new UserEntity { Id = Guid.NewGuid(), Name = "user2" };
            return new List<UserEntity> { user1, user2 };
        }


        private MockMessageRepository InitMockMessageRepository(MockUserRepository userRepository)
        {
            var messageRepository = new MockMessageRepository();
            List<MessageEntity> messages = CreateMessages(userRepository);
            messageRepository.Storage.AddRange(messages);
            return messageRepository;
        }


        private MockUserRepository InitMockUserRepository()
        {
            var repository = new MockUserRepository();
            List<UserEntity> users = CreateUsers();
            repository.Storage.AddRange(users);
            return repository;
        }
    }
}
