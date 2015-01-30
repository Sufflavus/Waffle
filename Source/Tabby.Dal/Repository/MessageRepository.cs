using System;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public class MessageRepository : Repository<MessageEntity>, IMessageRepository
    {
        //TODO: добавить IoC
        private readonly IContext Context;


        public MessageRepository():base()
        {
        }


        public MessageRepository(IContext context)
        {
            Context = context;
        }
    }
}
