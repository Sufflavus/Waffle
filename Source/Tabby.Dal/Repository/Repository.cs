using System;
using System.Collections.Generic;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        //TODO: добавить IoC
        protected IContext Context;


        protected Repository()
        {
            Context = new NHibernateContext();
        }

        protected Repository(IContext context)
        {
            Context = context;
        }


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
