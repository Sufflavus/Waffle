using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Linq;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Context
{
    public class NHibernateContext : IContext
    {
        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }


        public List<TEntity> Filter<TEntity>(Func<TEntity, bool> condition) where TEntity : BaseEntity
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                return session.Query<TEntity>()
                    .Where(condition)
                    .ToList();
            }
        }


        public List<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                return session.Query<TEntity>().ToList();
            }
        }


        public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                return session.Get<TEntity>(id);
            }
        }
    }
}
