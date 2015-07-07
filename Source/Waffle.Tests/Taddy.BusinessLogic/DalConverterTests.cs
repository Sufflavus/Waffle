using System;

using Bijuu.Contracts;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;

using Xunit;


namespace Waffle.Tests.Taddy.BusinessLogic
{
    public class DalConverterTests
    {
        [Fact]
        public void ToMessageInfo_GoodMessage_MessageInfo()
        {
            var message = new Message
            {
                Text = "text",
                CreateDate = DateTime.Now,
                SenderId = Guid.NewGuid(),
                RecipientId = Guid.NewGuid()
            };

            MessageInfo result = DalConverter.ToMessageInfo(message);

            Assert.Equal(message.Text, result.Text);
            Assert.Equal(message.SenderId, result.SenderId);
            Assert.Equal(message.RecipientId, result.RecipientId);
            Assert.Null(result.CreateDate);
            Assert.False(result.IsDelivered);
        }


        [Fact]
        public void ToMessageInfo_NullMessage_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessageInfo(null));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToMessage_GoodMessageInfo_Message()
        {
            var messageInfo = new MessageInfo
            {
                Text = "text",
                CreateDate = DateTime.Now,
                SenderId = Guid.NewGuid(),
                Sender = new UserInfo
                {
                    Id = Guid.NewGuid()
                }
            };

            Message result = DalConverter.ToMessage(messageInfo);

            Assert.Equal(messageInfo.Text, result.Text);
            Assert.Equal(messageInfo.CreateDate, result.CreateDate);
            Assert.Equal(messageInfo.SenderId, result.SenderId);
        }


        [Fact]
        public void ToMessage_NullMessageInfo_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessage(null));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToUser_GoodUserInfo_User()
        {
            var userInfo = new UserInfo { Id = Guid.NewGuid(), Name = "user", IsOnline = true };

            User result = DalConverter.ToUser(userInfo);

            Assert.Equal(userInfo.Id, result.Id);
            Assert.Equal(userInfo.Name, result.Name);
            Assert.True(userInfo.IsOnline);
        }


        [Fact]
        public void ToUser_NullUserInfo_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToUser(null));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
