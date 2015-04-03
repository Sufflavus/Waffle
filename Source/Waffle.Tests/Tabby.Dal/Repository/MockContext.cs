using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.Dal.Context;
using Bijuu.Dal.Domain;


namespace Waffle.Tests.Tabby.Dal.Repository
{
    //TODO: подобрать правильные моки http://nsubstitute.github.io/
    public class MockContext : IContext
    {
        public MockContext()
        {
            Storage = new List<BaseEntity>();
        }


        public List<BaseEntity> Storage { get; private set; }


        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var savedEntity = GetById<TEntity>(entity.Id);
            if (savedEntity != null)
            {
                Storage.Remove(savedEntity);
            }

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
