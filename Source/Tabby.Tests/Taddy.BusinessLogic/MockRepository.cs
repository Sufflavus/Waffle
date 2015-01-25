using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;
using Tabby.Dal.Repository;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    //TODO: подобрать правильные моки
    public class MockRepository : IUniversalRepository
    {
        public MockRepository()
        {
            Storage = new List<BaseEntity>();
        }


        public List<BaseEntity> Storage { get; private set; }


        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Storage.Add(entity);
        }


        public List<TEntity> Filter<TEntity>(Func<TEntity, bool> condition) where TEntity : BaseEntity
        {
            return Storage.Select(x => ((TEntity)x))
                .Where(condition)
                .ToList();
        }


        public List<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return Storage.Select(x => ((TEntity)x)).ToList();
        }


        public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            return Storage.Select(x => ((TEntity)x)).FirstOrDefault(x => x.Id == id);
        }
    }
}
