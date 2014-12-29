using System;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    public sealed class BusinessLogicAdapter
    {
        public static Message CreateMessage(string messageText)
        {
            return new Message { Text = messageText };
        }
    }
}
