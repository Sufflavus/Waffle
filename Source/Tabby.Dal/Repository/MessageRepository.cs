using System;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;


namespace Tabby.Dal.Repository
{
    public class MessageRepository : Repository<MessageEntity>, IMessageRepository
    {
        public MessageRepository()
        {
        }


        public MessageRepository(IContext context) : base(context)
        {
        }
    }
}
