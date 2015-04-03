using System;

using Bijuu.Contracts;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Models;

using Xunit;


namespace Waffle.Tests.Taddy.BusinessLogic
{
    public class DalConverterTests
    {
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
            var userInfo = new UserInfo { Id = Guid.NewGuid(), Name = "user" };

            User result = DalConverter.ToUser(userInfo);

            Assert.Equal(userInfo.Id, result.Id);
            Assert.Equal(userInfo.Name, result.Name);
        }


        [Fact]
        public void ToUser_NullUserInfo_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToUser(null));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
