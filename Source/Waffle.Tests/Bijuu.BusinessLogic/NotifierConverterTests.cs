using System;

using Bijuu.BusinessLogic;
using Bijuu.Dal.Domain;

using Ginger.Contracts;

using Xunit;


namespace Waffle.Tests.Bijuu.BusinessLogic
{
    public class NotifierConverterTests
    {
        [Fact]
        public void ToMessageRecord_GoodMessageEntity_MessageRecord()
        {
            Guid userId1 = Guid.NewGuid();
            Guid userId2 = Guid.NewGuid();
            var message = new MessageEntity
            {
                Text = "text",
                CreateDate = DateTime.Now,
                SenderId = userId1,
                Sender = new UserEntity
                {
                    Id = userId1,
                    Name = "user1"
                },
                RecipientId = userId2,
                Recipient = new UserEntity
                {
                    Id = userId2,
                    Name = "user2"
                }
            };

            MessageRecord result = NotifierConverter.ToMessageRecord(message);

            Assert.Equal(message.Text, result.Text);
            Assert.Equal(message.CreateDate, result.CreateDate);
            Assert.Equal(message.SenderId, result.SenderId);
            Assert.Equal(message.Sender.Id, result.Sender.Id);
            Assert.Equal(message.RecipientId, result.RecipientId);
            Assert.Equal(message.Recipient.Id, result.Recipient.Id);
        }


        [Fact]
        public void ToMessageRecord_NullMessageEntity_Throws()
        {
            MessageEntity entity = null;

            Exception result = Assert.Throws<ArgumentException>(() => NotifierConverter.ToMessageRecord(entity));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToMessageRecord_NullSenderAndRecipient_MessageRecord()
        {
            var message = new MessageEntity
            {
                Id = Guid.NewGuid(),
                Text = "text",
                CreateDate = DateTime.Now,
                SenderId = Guid.NewGuid(),
                Sender = null,
                RecipientId = Guid.NewGuid(),
                Recipient = null
            };

            MessageRecord result = NotifierConverter.ToMessageRecord(message);

            Assert.Equal(message.Id, result.Id);
            Assert.Equal(message.Text, result.Text);
            Assert.Equal(message.CreateDate, result.CreateDate);
            Assert.Equal(message.SenderId, result.SenderId);
            Assert.Null(result.Sender);
            Assert.Equal(message.RecipientId, result.RecipientId);
            Assert.Null(result.Recipient);
        }


        [Fact]
        public void ToUserRecord_GoodUserEntity_UserRecord()
        {
            var entity = new UserEntity { Id = Guid.NewGuid(), Name = "user" };

            UserRecord result = NotifierConverter.ToUserRecord(entity);

            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.Name, result.Name);
        }


        [Fact]
        public void ToUserRecord_NullUserEntity_Throws()
        {
            UserEntity entity = null;

            Exception result = Assert.Throws<ArgumentException>(() => NotifierConverter.ToUserRecord(entity));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
