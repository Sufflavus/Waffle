using System;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Converters
{
    public sealed class BusinessLogicConverter
    {
        private static readonly string[] NotAllowedSymbolsInUserName = new string[] { " " };


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

            string notmalisedName = userName.Trim();

            foreach (string symbol in NotAllowedSymbolsInUserName)
            {
                if (notmalisedName.IndexOf(symbol, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }
                throw new ArgumentException("userName contains not allowed symbol '{0}'", symbol);
            }

            return new User { Name = userName };
        }
    }
}
