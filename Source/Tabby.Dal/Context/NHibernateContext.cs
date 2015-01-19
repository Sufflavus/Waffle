using System;

using NHibernate;

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


        public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                return session.Get<TEntity>(id);
            }
        }
    }
}
