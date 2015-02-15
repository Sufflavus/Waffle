using System;

using FluentNHibernate.Mapping;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Mappings
{
    public class MessageEntityMap : ClassMap<MessageEntity>
    {
        public MessageEntityMap()
        {
            Table("dbo.Message");

            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb();

            Map(x => x.Text)
                .Not.Nullable();

            Map(x => x.CreateDate)
                .Generated
                .Insert()
                .Not.Nullable();

            Map(x => x.IsDelivered)
                .Not.Nullable();

            Map(x => x.SenderId, "SenderId")
                .Not.Nullable();

            References(x => x.Sender, "SenderId")
                .Unique()
                .LazyLoad(Laziness.False)
                .Not.Insert()
                .Not.Update();

            Map(x => x.RecipientId, "RecipientId")
                .Not.Nullable();

            References(x => x.Recipient, "RecipientId")
                .Unique()
                .LazyLoad(Laziness.False)
                .Not.Insert()
                .Not.Update();
        }
    }
}
