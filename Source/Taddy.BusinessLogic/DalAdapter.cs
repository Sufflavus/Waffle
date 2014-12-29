using System;

using Tabby.Dal;


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
