using System;
using System.Collections.Generic;

using Microsoft.Practices.Unity;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;


namespace Tabby.Dal.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected Repository(IContext context)
        {
            Context = context;
        }


        [Dependency]
        public IContext Context { get; set; }


        public void AddOrUpdate(TEntity entity)
        {
            Context.AddOrUpdate(entity);
        }


        public List<TEntity> Filter(Func<TEntity, bool> condition)
        {
            return Context.Filter(condition);
        }


        public List<TEntity> GetAll()
        {
            return Context.GetAll<TEntity>();
        }


        public TEntity GetById(Guid id)
        {
            return Context.GetById<TEntity>(id);
        }
    }
}
