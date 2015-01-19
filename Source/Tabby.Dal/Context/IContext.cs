using System;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Context
{
    public interface IContext
    {
        void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity;
        TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity;
    }
}
