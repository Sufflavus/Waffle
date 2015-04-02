using System;
using System.Collections.Generic;

using Bijuu.Dal.Domain;


namespace Bijuu.Dal.Context
{
    public interface IContext
    {
        void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity;
        List<TEntity> Filter<TEntity>(Func<TEntity, bool> condition) where TEntity : BaseEntity;
        List<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;
        TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity;
    }
}
