using System;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public interface IUniversalRepository
    {
        void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity;
        TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity;
    }
}
