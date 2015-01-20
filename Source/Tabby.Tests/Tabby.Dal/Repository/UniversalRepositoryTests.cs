using System;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;

using Xunit;


namespace Tabby.Tests.Tabby.Dal.Repository
{
    public class UniversalRepositoryTests
    {
        [Fact]
        public void AddOrUpdate_CorrectInput_Saved_In_Context()
        {
            var context = new MockContext();
            IUniversalRepository repository = new UniversalRepository(context);
            var entity = new MessageEntity { Id = Guid.NewGuid(), Text = "test", CreateDate = DateTime.Now };

            repository.AddOrUpdate(entity);

            BaseEntity actual = context.Storage[0];
            Assert.Equal(entity, actual);
            Assert.IsType<MessageEntity>(actual);
            Assert.Equal(entity.Id, actual.Id);
            Assert.Equal(entity.Text, ((MessageEntity)actual).Text);
            Assert.Equal(entity.CreateDate, ((MessageEntity)actual).CreateDate);
        }
    }
}
