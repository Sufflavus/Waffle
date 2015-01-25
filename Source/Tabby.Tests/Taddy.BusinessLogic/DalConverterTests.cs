using System;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic;

using Xunit;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    public class DalConverterTests
    {
        [Fact]
        public void ToMessageEntity_CorrectInput()
        {
            var message = new Message { Text = "text", CreateDate = DateTime.Now };

            MessageEntity result = DalConverter.ToMessageEntity(message);

            Assert.Equal(result.Text, message.Text);
            Assert.Null(result.CreateDate);
        }


        [Fact]
        public void ToMessageEntity_IncorrectInput_ThrowsException()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessageEntity(null));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void ToMessage_CorrectInput()
        {
            var entity = new MessageEntity { Text = "text", CreateDate = DateTime.Now };

            Message result = DalConverter.ToMessage(entity);

            Assert.Equal(result.Text, entity.Text);
            Assert.Equal(result.CreateDate, entity.CreateDate);
        }


        [Fact]
        public void ToMessage_IncorrectInput_ThrowsException()
        {
            Exception result = Assert.Throws<ArgumentException>(() => DalConverter.ToMessage(null));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
