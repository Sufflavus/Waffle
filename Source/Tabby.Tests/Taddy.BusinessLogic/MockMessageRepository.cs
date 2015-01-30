﻿using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    //TODO: подобрать правильные моки
    public class MockMessageRepository : IMessageRepository
    {
        public MockMessageRepository()
        {
            Storage = new List<MessageEntity>();
        }


        public List<MessageEntity> Storage { get; private set; }


        public void AddOrUpdate(MessageEntity entity)
        {
            Storage.Add(entity);
        }


        public List<MessageEntity> Filter(Func<MessageEntity, bool> condition)
        {
            return Storage.Where(condition).ToList();
        }


        public List<MessageEntity> GetAll()
        {
            return Storage;
        }


        public MessageEntity GetById(Guid id)
        {
            return Storage.FirstOrDefault(x => x.Id == id);
        }
    }
}
