using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;

using System.Linq;


namespace Tabby.Tests.Tabby.Dal.Repository
{
    //TODO: подобрать правильные моки
    public class MockContext : IContext
    {
        public MockContext()
        {
            Storage=new List<BaseEntity>();
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
