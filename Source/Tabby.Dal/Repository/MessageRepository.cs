using System;
using System.Collections.Generic;

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


        public List<MessageEntity> GetNewMessages(Guid userId)
        {
            var user = Context.GetById<UserEntity>(userId);
            return Context.Filter<MessageEntity>(x => !x.Recipients.Contains(user) && x.UserId != userId);
        }
    }
}
