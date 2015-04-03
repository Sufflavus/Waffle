using System;

using Bijuu.Dal.Domain;

using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Xunit;


namespace Waffle.Tests.Tabby.Dal
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
