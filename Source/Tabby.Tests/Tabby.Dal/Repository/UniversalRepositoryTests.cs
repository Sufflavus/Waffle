using System;
using System.Collections.Generic;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;

using Xunit;


namespace Tabby.Tests.Tabby.Dal.Repository
{
    public class UniversalRepositoryTests : IUseFixture<MockContext>
    {
        private MockContext _context;



        public void SetFixture(MockContext data)
        {
            _context = new MockContext();
        }

        [Fact]
        public void AddOrUpdate_CorrectInput_SavedInContext()
        {
            IUniversalRepository repository = new UniversalRepository(_context);
            var entity = new MessageEntity { Id = Guid.NewGuid(), Text = "test", CreateDate = DateTime.Now };

            repository.AddOrUpdate(entity);

            BaseEntity actual = _context.Storage[0];
            Assert.Equal(entity, actual);
            Assert.IsType<MessageEntity>(actual);
            Assert.Equal(entity.Id, actual.Id);
            Assert.Equal(entity.Text, ((MessageEntity)actual).Text);
            Assert.Equal(entity.CreateDate, ((MessageEntity)actual).CreateDate);
        }


        [Fact]
        public void GetAll_ReturnAllFromContext()
        {
            IUniversalRepository repository = new UniversalRepository(_context);
            var entity1 = new MessageEntity { Id = Guid.NewGuid(), Text = "test1", CreateDate = DateTime.Now };
            var entity2 = new MessageEntity { Id = Guid.NewGuid(), Text = "test2", CreateDate = DateTime.Now };

            _context.Storage.Add(entity1);
            _context.Storage.Add(entity2);

            List<MessageEntity> result = repository.GetAll<MessageEntity>();

            Assert.Equal(result.Count, 2);
            Assert.Equal(result[0], entity1);
            Assert.Equal(result[1], entity2);
            Assert.Equal(result[0].Text, entity1.Text);
            Assert.Equal(result[1].Text, entity2.Text);
        }
    }
}
