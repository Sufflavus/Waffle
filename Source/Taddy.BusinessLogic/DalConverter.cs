using System;

using Tabby.Dal.Domain;


namespace Taddy.BusinessLogic
{
    public sealed class DalConverter
    {
        public static MessageEntity ToMessageEntity(Message message)
        {
            return new MessageEntity { Text = message.Text };
        }
    }
}
