using System;

using Tabby.Client;

using Taddy.BusinessLogic;

using Xunit;
using Xunit.Extensions;


namespace Tabby.Tests.Tabby.Client
{
    public class BusinessLogicConverterTests
    {
        [Theory]
        [InlineData("text")]
        [InlineData("   text   ")]
        [InlineData("qwewqe qweqwe qweqwe")]
        [InlineData("rtyrtyrty rtyrtyrtyrtyrty  rtyrtyrty ")]
        public void ToMessage_GoodText_ReturnsMessage(string messageText)
        {
            Message result = BusinessLogicConverter.ToMessage(messageText);

            Assert.Equal(messageText, result.Text);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("      ")]
        public void ToMessage_BadText_Throws(string messageText)
        {
            Exception result = Assert.Throws<ArgumentException>(() => BusinessLogicConverter.ToMessage(messageText));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}
