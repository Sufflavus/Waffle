using System;

using Tabby.Dal;
using Tabby.Dal.Domain;


namespace Taddy.BusinessLogic
{
    public sealed class DalAdapter
    {
        public static MessageEntity CreateMessageEntity(Message message)
        {
            return new MessageEntity { Text = message.Text };
        }
    }
}
