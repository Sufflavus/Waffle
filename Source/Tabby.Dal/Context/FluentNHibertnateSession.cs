using System;

using Bijuu.Dal.Domain;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;


namespace Bijuu.Dal.Context
{
    public sealed class FluentNHibertnateSession : IDisposable
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionManagerHelper.ConnectionString))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MessageEntity>())
                        .ExposeConfiguration(BuildSchema)
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }


        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


        public void Dispose()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Dispose();
            }
        }


        private static void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(false, true);
        }
    }
}
