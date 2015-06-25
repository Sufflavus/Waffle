using System;

using Ginger.Contracts;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;

using Xunit;
using Xunit.Extensions;


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
                RecipientId = Guid.NewGuid(),
                Sender = new UserRecord { Id = Guid.NewGuid() },
            };

            Message result = NotifierConverter.ToMessage(record);

            Assert.Equal(record.Text, result.Text);
            Assert.Equal(record.CreateDate, result.CreateDate);
            Assert.Equal(record.SenderId, result.SenderId);
            Assert.Equal(record.Sender.Id, result.Sender.Id);
            Assert.Equal(record.RecipientId, result.RecipientId);
        }


        [Fact]
        public void ToMessage_NullMessageRecord_ReturnsNull()
        {
            Message result = NotifierConverter.ToMessage(null);
            Assert.Equal(null, result);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToUser_GoodUserRecord_ReturnsUser(bool isOnline)
        {
            var record = new UserRecord { Id = Guid.NewGuid(), Name = "user", IsOnline = isOnline };

            User result = NotifierConverter.ToUser(record);

            Assert.Equal(record.Id, result.Id);
            Assert.Equal(record.Name, result.Name);
            Assert.Equal(isOnline, result.IsOnline);
        }


        [Fact]
        public void ToUser_NullUserRecord_ReturnsNull()
        {
            User result = NotifierConverter.ToUser(null);
            Assert.Equal(null, result);
        }
    }
}
