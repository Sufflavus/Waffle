using System;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic;

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
            var entity = new MessageEntity { Text = "text", CreateDate = DateTime.Now };

            Message result = DalConverter.ToMessage(entity);

            Assert.Equal(entity.Text, result.Text);
            Assert.Equal(entity.CreateDate, result.CreateDate);
        }


        [Fact]
        public void ToMessage_NullMessageEntity_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessage(null));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
