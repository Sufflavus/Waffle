using System;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    public sealed class BusinessLogicConverter
    {
        public static Message ToMessage(string messageText)
        {
            return new Message { Text = messageText };
        }
    }
}
