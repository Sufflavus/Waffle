using System;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Context
{
    public sealed class FluentNHibertnateSession : IDisposable
    {
        private const string ConnectionString = @"Server=TATA-SPACESHIP\SQLEXPRESS;database=Waffle; Integrated Security=SSPI";
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString))
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
