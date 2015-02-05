using System;

using Taddy.BusinessLogic.Models;


namespace Tabby.Client
{
    public sealed class BusinessLogicConverter
    {
        public static Message ToMessage(string messageText)
        {
            if (string.IsNullOrEmpty(messageText) || string.IsNullOrEmpty(messageText.Trim()))
            {
                throw new ArgumentException("messageText can't be empty");
            }

            return new Message { Text = messageText };
        }


        public static User ToUser(string userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userName.Trim()))
            {
                throw new ArgumentException("userName can't be empty");
            }

            return new User { Name = userName };
        }
    }
}
