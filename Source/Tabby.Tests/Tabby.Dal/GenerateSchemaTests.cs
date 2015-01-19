using System;

using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Tabby.Dal.Domain;

using Xunit;


namespace Tabby.Tests.Tabby.Dal
{
    public class GenerateSchemaTests
    {
        [Fact(Skip = "A real DB is required")]
        public void Can_Generate_Schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(MessageEntity).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}
