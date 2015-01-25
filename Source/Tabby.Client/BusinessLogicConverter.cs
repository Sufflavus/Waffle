using System;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    public sealed class BusinessLogicConverter
    {
        public static Message ToMessage(string messageText)
        {
            if (string.IsNullOrEmpty(messageText.Trim()))
            {
                throw new ArgumentException("messageText can't be empty");
            }

            return new Message { Text = messageText };
        }
    }
}
