using System;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Models;

using Xunit;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    public class DalConverterTests
    {
        [Fact]
        public void ToMessageEntity_GoodMessage_MessageEntity()
        {
            var message = new Message { Text = "text", CreateDate = DateTime.Now };

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
        public void ToMessage_GoodMessageEntity_Message()
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

            Message result = DalConverter.ToMessage(entity);

            Assert.Equal(entity.Text, result.Text);
            Assert.Equal(entity.CreateDate, result.CreateDate);
            Assert.Equal(entity.SenderId, result.SenderId);
            Assert.Equal(entity.Sender.Id, result.Sender.Id);
            Assert.Equal(entity.Sender.Name, result.Sender.Name);
        }


        [Fact]
        public void ToMessage_NullMessageEntity_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessage(null));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToUserEntity_GoodUser_UserEntity()
        {
            var user = new User { Name = "user" };

            UserEntity result = DalConverter.ToUserEntity(user);

            Assert.Equal(user.Name, result.Name);
            Assert.False(result.IsOnline);
        }


        [Fact]
        public void ToUserEntity_NullUser_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToUserEntity(null));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToUser_GoodUserEntity_User()
        {
            var enrity = new UserEntity { Id = Guid.NewGuid(), Name = "user" };

            User result = DalConverter.ToUser(enrity);

            Assert.Equal(enrity.Id, result.Id);
            Assert.Equal(enrity.Name, result.Name);
        }


        [Fact]
        public void ToUser_NullUserEntity_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToUser(null));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
