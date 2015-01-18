using System;

using NHibernate;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Context
{
    public class NHibernateContext : IContext
    {
        public void Add(BaseEntity entity)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
