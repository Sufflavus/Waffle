using System;
using System.Collections.Generic;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository.Interfaces
{
    public interface IMessageRepository : IRepository<MessageEntity>
    {
        List<MessageEntity> GetNewMessages(Guid userId);
    }
}
