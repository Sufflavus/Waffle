using System;

using FluentNHibernate.Mapping;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Mappings
{
    public class UserEntityMap : ClassMap<UserEntity>
    {
        public UserEntityMap()
        {
            Table("[dbo].[User]");

            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Not.Nullable();

            Map(x => x.IsOnline)
                .Not.Nullable();
        }
    }
}
