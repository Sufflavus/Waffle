using System;
using System.Collections.Generic;
using System.Linq;

using NSubstitute;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;

using Xunit;


namespace Waffle.Tests.Tabby.Dal.Repository
{
    public class MessageRepositoryTests : IUseFixture<MockContext>
    {
        private MockContext _context;
        private MessageEntity _message1;
        private MessageEntity _message2;


        [Fact]
        public void AddOrUpdate_AddOrUpdateCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IMessageRepository repository = new MessageRepository(context);
            var entity = new MessageEntity { Id = Guid.NewGuid(), Text = "test", CreateDate = DateTime.Now };

            repository.AddOrUpdate(entity);

            context.Received().AddOrUpdate(entity);
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
            Assert.False(((MessageEntity)actual).IsDelivered);
            Assert.Equal(itemsCount + 1, _context.Storage.Count);
        }


        [Fact]
        public void AddOrUpdate_GoodInput_NotDeleveredMessage()
        {
            IMessageRepository repository = new MessageRepository(_context);
            var entity = new MessageEntity { Id = Guid.NewGuid(), Text = "test", CreateDate = DateTime.Now };

            repository.AddOrUpdate(entity);

            BaseEntity actual = _context.Storage.FirstOrDefault(x => x.Id == entity.Id);
            Assert.False(((MessageEntity)actual).IsDelivered);
        }


        [Fact]
        public void AddOrUpdate_GoodInput_UpdatedInContext()
        {
            IMessageRepository repository = new MessageRepository(_context);
            var entity = new MessageEntity { Id = _message1.Id, Text = "test3", IsDelivered = true };
            int itemsCount = _context.Storage.Count;

            repository.AddOrUpdate(entity);

            BaseEntity actual = _context.Storage.FirstOrDefault(x => x.Id == entity.Id);
            Assert.Equal(entity, actual);
            Assert.IsType<MessageEntity>(actual);
            Assert.Equal(_message1.Id, actual.Id);
            Assert.NotEqual(_message1.Text, ((MessageEntity)actual).Text);
            Assert.Equal(entity.Text, ((MessageEntity)actual).Text);
            Assert.Equal(entity.CreateDate, ((MessageEntity)actual).CreateDate);
            Assert.Equal(entity.IsDelivered, ((MessageEntity)actual).IsDelivered);
            Assert.Equal(itemsCount, _context.Storage.Count);
        }


        [Fact]
        public void Filter_BadInput_EmptyResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            List<MessageEntity> result = repository.Filter(x => x.Id == Guid.NewGuid());

            Assert.Equal(0, result.Count);
        }


        [Fact]
        public void Filter_FilterCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IMessageRepository repository = new MessageRepository(context);
            Func<MessageEntity, bool> condition = x => x.Text == "text";

            repository.Filter(condition);

            context.Received().Filter(condition);
        }


        [Fact]
        public void Filter_GoodInput_CorrectResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            List<MessageEntity> result = repository.Filter(x => x.Text == _message1.Text);

            Assert.Equal(1, result.Count);
            Assert.Equal(_message1, result[0]);
            Assert.Equal(_message1.Text, result[0].Text);
        }


        [Fact]
        public void GetAll_CorrectResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            List<MessageEntity> result = repository.GetAll();

            Assert.Equal(_context.Storage.Count, result.Count);
            Assert.Equal(_message1, result[0]);
            Assert.Equal(_message2, result[1]);
            Assert.Equal(_message1.Text, result[0].Text);
            Assert.Equal(_message2.Text, result[1].Text);
        }


        [Fact]
        public void GetAll_GetAllCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IMessageRepository repository = new MessageRepository(context);

            repository.GetAll();

            context.Received().GetAll<MessageEntity>();
        }


        [Fact]
        public void GetById_ExistingId_CorrectResult()
        {
            IMessageRepository repository = new MessageRepository(_context);

            MessageEntity result = repository.GetById(_message1.Id);

            Assert.Equal(_message1, result);
            Assert.Equal(_message1.Text, result.Text);
        }


        [Fact]
        public void GetById_GetByIdCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IMessageRepository repository = new MessageRepository(context);
            Guid id = Guid.NewGuid();

            repository.GetById(id);

            context.Received().GetById<MessageEntity>(id);
        }


        [Fact]
        public void GetById_NotExistingId_Null()
        {
            IMessageRepository repository = new MessageRepository(_context);

            MessageEntity result = repository.GetById(Guid.NewGuid());

            Assert.Null(result);
        }


        public void SetFixture(MockContext data)
        {
            _context = new MockContext();
            _message1 = new MessageEntity { Id = Guid.NewGuid(), Text = "test1", CreateDate = DateTime.Now };
            _message2 = new MessageEntity { Id = Guid.NewGuid(), Text = "test2", CreateDate = DateTime.Now };
            _context.Storage.Add(_message1);
            _context.Storage.Add(_message2);
        }
    }
}
