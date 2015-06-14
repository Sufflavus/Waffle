using System;

using Bijuu.BusinessLogic;
using Bijuu.Contracts;
using Bijuu.Dal.Domain;

using Xunit;


namespace Waffle.Tests.Bijuu.BusinessLogic
{
    public class DalConverterTests
    {
        [Fact]
        public void ToMessageEntity_GoodMessageInfo_MessageEntity()
        {
            var message = new MessageInfo { Text = "text", CreateDate = DateTime.Now };

            MessageEntity result = DalConverter.ToMessageEntity(message);

            Assert.Equal(message.Text, result.Text);
            Assert.Null(result.CreateDate);
            Assert.False(result.IsDelivered);
        }


        [Fact]
        public void ToMessageEntity_NullMessage_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessageEntity(null));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToMessageInfo_GoodMessageEntity_MessageInfo()
        {
            Guid userId1 = Guid.NewGuid();
            Guid userId2 = Guid.NewGuid();
            var entity = new MessageEntity
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

            MessageInfo result = DalConverter.ToMessageInfo(entity);

            Assert.Equal(entity.Text, result.Text);
            Assert.Equal(entity.CreateDate, result.CreateDate);
            Assert.Equal(entity.SenderId, result.SenderId);
            Assert.Equal(entity.Sender.Id, result.Sender.Id);
            Assert.Equal(entity.Sender.Name, result.Sender.Name);
            Assert.Equal(entity.RecipientId, result.RecipientId);
            Assert.Equal(entity.Recipient.Id, result.Recipient.Id);
            Assert.Equal(entity.Recipient.Name, result.Recipient.Name);
        }


        [Fact]
        public void ToMessageInfo_NullMessageEntity_Throws()
        {
            MessageEntity entity = null;

            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessageInfo(entity));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToUserInfo_GoodUserEntity_UserInfo()
        {
            var entity = new UserEntity { Id = Guid.NewGuid(), Name = "user" };

            UserInfo result = DalConverter.ToUserInfo(entity);

            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.Name, result.Name);
        }


        [Fact]
        public void ToUserInfo_NullUserEntity_Throws()
        {
            UserEntity entity = null;

            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToUserInfo(entity));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
