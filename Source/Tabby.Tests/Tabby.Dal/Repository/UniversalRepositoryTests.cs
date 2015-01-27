﻿using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;

using Xunit;


namespace Tabby.Tests.Tabby.Dal.Repository
{
    public class UniversalRepositoryTests : IUseFixture<MockContext>
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
        public void AddOrUpdate_CorrectInput_SavedInContext()
        {
            IUniversalRepository repository = new UniversalRepository(_context);
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
        public void Filter_ReturnCorrectResult()
        {
            IUniversalRepository repository = new UniversalRepository(_context);

            List<MessageEntity> result = repository.Filter<MessageEntity>(x => x.Text == _entity1.Text);

            Assert.Equal(1, result.Count);
            Assert.Equal(_entity1, result[0]);
            Assert.Equal(_entity1.Text, result[0].Text);
        }


        [Fact]
        public void Filter_ReturnEmptyResult()
        {
            IUniversalRepository repository = new UniversalRepository(_context);

            List<MessageEntity> result = repository.Filter<MessageEntity>(x => x.Id == Guid.NewGuid());

            Assert.Equal(0, result.Count);
        }


        [Fact]
        public void GetAll_ReturnAllFromContext()
        {
            IUniversalRepository repository = new UniversalRepository(_context);

            List<MessageEntity> result = repository.GetAll<MessageEntity>();

            Assert.Equal(_context.Storage.Count, result.Count);
            Assert.Equal(_entity1, result[0]);
            Assert.Equal(_entity2, result[1]);
            Assert.Equal(_entity1.Text, result[0].Text);
            Assert.Equal(_entity2.Text, result[1].Text);
        }


        [Fact]
        public void GetById_ExistingId_CorrectResult()
        {
            IUniversalRepository repository = new UniversalRepository(_context);

            var result = repository.GetById<MessageEntity>(_entity1.Id);

            Assert.Equal(_entity1, result);
            Assert.Equal(_entity1.Text, result.Text);
        }


        [Fact]
        public void GetById_NotExistingId_Null()
        {
            IUniversalRepository repository = new UniversalRepository(_context);

            var result = repository.GetById<MessageEntity>(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}
