using System;

using Tabby.Terminal.Converters;

using Taddy.BusinessLogic.Models;

using Xunit;
using Xunit.Extensions;


namespace Waffle.Tests.Tabby.Terminal
{
    public class BusinessLogicConverterTests
    {
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
        [InlineData("qwewqe  qweqwe")]
        [InlineData("qwewqe qweqwe qweqwe")]
        public void ToUser_BadText_Throws(string userName)
        {
            Exception result = Assert.Throws<ArgumentException>(() => BusinessLogicConverter.ToUser(userName));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Theory]
        [InlineData("text")]
        [InlineData("   text   ")]
        [InlineData("UserName ")]
        [InlineData("UserName123 ")]
        public void ToUser_GoodText_ReturnsUser(string userName)
        {
            User result = BusinessLogicConverter.ToUser(userName);

            Assert.Equal(userName, result.Name);
        }
    }
}
