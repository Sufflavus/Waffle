using System;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public class MessageRepository : Repository<MessageEntity>, IMessageRepository
    {
        public MessageRepository()
        {
        }


        public MessageRepository(IContext context):base(context)
        {
        }
    }
}
