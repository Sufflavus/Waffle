using System;

using Ginger.Contracts;

using Tabby.Terminal.Converters;
using Taddy.BusinessLogic.Models;

using Xunit;


namespace Waffle.Tests.Tabby.Terminal
{
    public class NotifierConverterTests
    {
        [Fact]
        public void ToMessage_GoodMessageRecord_ReturnsMessage()
        {
            var record = new MessageRecord
            {
                Id = Guid.NewGuid(),
                Text = "text",
                CreateDate = DateTime.Now,
                SenderId = Guid.NewGuid(),
                Sender = new UserRecord { Id = Guid.NewGuid() },
            };

            Message result = NotifierConverter.ToMessage(record);

            Assert.Equal(record.Text, result.Text);
            Assert.Equal(record.CreateDate, result.CreateDate);
            Assert.Equal(record.SenderId, result.SenderId);
            Assert.Equal(record.Sender.Id, result.Sender.Id);
        }


        [Fact]
        public void ToMessage_NullMessageRecord_ReturnsNull()
        {
            Message result = NotifierConverter.ToMessage(null);
            Assert.Equal(null, result);
        }


        [Fact]
        public void ToUser_GoodUserRecord_ReturnsUser()
        {
            var record = new UserRecord { Id = Guid.NewGuid(), Name = "user" };

            User result = NotifierConverter.ToUser(record);

            Assert.Equal(record.Id, result.Id);
            Assert.Equal(record.Name, result.Name);
        }


        [Fact]
        public void ToUser_NullUserRecord_ReturnsNull()
        {
            User result = NotifierConverter.ToUser(null);
            Assert.Equal(null, result);
        }
    }
}
