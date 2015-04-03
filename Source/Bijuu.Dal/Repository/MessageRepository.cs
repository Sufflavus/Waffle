using System;

using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository.Interfaces;


namespace Bijuu.Dal.Repository
{
    public class MessageRepository : Repository<MessageEntity>, IMessageRepository
    {
    }
}
