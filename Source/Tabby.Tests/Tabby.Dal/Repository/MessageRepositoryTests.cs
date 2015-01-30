using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;

using Xunit;


namespace Tabby.Tests.Tabby.Dal.Repository
{
    public class MessageRepositoryTests : IUseFixture<MockContext>
    {
        private MockContext _context;
        private MessageEntity _entity1;
        private MessageEntity _entity2;

        public void SetFixture(MockContext data)
        {
            _context = new MockContext();
            _entity1 = new MessageEntity { Id = Guid.NewGuid(), Text = "test1", CreateDate = DateTime.Now };
            _entity2 = new MessageEntity { Id = Guid.NewGuid(), Text = "test2", CreateDate = DateTime.Now };
            _context.Storage.Add(_entity1);
            _context.Storage.Add(_entity2);
        }

        [Fact]
        public void AddOrUpdate_GoodInput_AddedInContext()
        {
            IMessageRepository repository = new MessageRepository(_context);
            var entity = new MessageEntity { Id = Guid.NewGuid(), Text = "test", CreateDate = DateTime.Now };
            int itemsCount = _context.Storage.Count;

            repository.AddOrUpdate(entity);

            BaseEntity actual = _context.Storage.FirstOrDefault(x => x.Id == entity.Id);
            Assert.Equal(entity, actual);
            Assert.IsType<MessageEntity>(actual);
            Assert.Equal(entity.Id, actual.Id);
            Assert.Equal(entity.Text, ((MessageEntity)actual).Text);
            Assert.Equal(entity.CreateDate, ((MessageEntity)actual).CreateDate);
            Assert.Equal(itemsCount + 1, _context.Storage.Count);
        }

        [Fact]
        public void AddOrUpdate_GoodInput_UpdatedInContext()
        {
            IMessageRepository repository = new MessageRepository(_context);
            var entity = new MessageEntity { Id = _entity1.Id, Text = "test3" };
            int itemsCount = _context.Storage.Count;

            repository.AddOrUpdate(entity);

            BaseEntity actual = _context.Storage.FirstOrDefault(x => x.Id == entity.Id);
            Assert.Equal(entity, actual);
            Assert.IsType<MessageEntity>(actual);
            Assert.Equal(_entity1.Id, actual.Id);
            Assert.NotEqual(_entity1.Text, ((MessageEntity)actual).Text);
            Assert.Equal(entity.Text, ((MessageEntity)actual).Text);
            Assert.Equal(entity.CreateDate, ((MessageEntity)actual).CreateDate);
            Assert.Equal(itemsCount, _context.Storage.Count);
        }


        [Fact]
        public void Filter_GoodInput_CorrectResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            List<MessageEntity> result = repository.Filter(x => x.Text == _entity1.Text);

            Assert.Equal(1, result.Count);
            Assert.Equal(_entity1, result[0]);
            Assert.Equal(_entity1.Text, result[0].Text);
        }


        [Fact]
        public void Filter_BadInput_EmptyResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            List<MessageEntity> result = repository.Filter(x => x.Id == Guid.NewGuid());

            Assert.Equal(0, result.Count);
        }


        [Fact]
        public void GetAll_CorrectResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            List<MessageEntity> result = repository.GetAll();

            Assert.Equal(_context.Storage.Count, result.Count);
            Assert.Equal(_entity1, result[0]);
            Assert.Equal(_entity2, result[1]);
            Assert.Equal(_entity1.Text, result[0].Text);
            Assert.Equal(_entity2.Text, result[1].Text);
        }


        [Fact]
        public void GetById_ExistingId_CorrectResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            MessageEntity result = repository.GetById(_entity1.Id);

            Assert.Equal(_entity1, result);
            Assert.Equal(_entity1.Text, result.Text);
        }


        [Fact]
        public void GetById_NotExistingId_Null()
        {
            IMessageRepository repository = new MessageRepository(_context);

            MessageEntity result = repository.GetById(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}
