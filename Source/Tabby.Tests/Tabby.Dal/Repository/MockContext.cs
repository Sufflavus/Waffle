using System;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;


namespace Tabby.Tests.Tabby.Dal.Repository
{
    //TODO: подобрать правильные моки
    public class MockContext : IContext
    {
        public BaseEntity Entity { get; private set; }


        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Entity = entity;
        }


        public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            return Entity as TEntity;
        }
    }
}
