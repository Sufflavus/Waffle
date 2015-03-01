using System;

using NSubstitute;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;

using Xunit;


namespace Waffle.Tests.Tabby.Dal.Repository
{
    public class UserRepositoryTests : IUseFixture<MockContext>
    {
        private MockContext _context;


        [Fact]
        public void AddOrUpdate_AddOrUpdateCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IUserRepository repository = new UserRepository(context);
            var entity = new UserEntity { Id = Guid.NewGuid() };

            repository.AddOrUpdate(entity);

            context.Received().AddOrUpdate(entity);
        }


        [Fact]
        public void Filter_FilterCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IUserRepository repository = new UserRepository(context);
            Func<UserEntity, bool> condition = x => x.Name == "name";

            repository.Filter(condition);

            context.Received().Filter(condition);
        }


        [Fact]
        public void GetAll_GetAllCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IUserRepository repository = new UserRepository(context);

            repository.GetAll();

            context.Received().GetAll<UserEntity>();
        }


        [Fact]
        public void GetById_GetByIdCalledInContext()
        {
            var context = Substitute.For<IContext>();
            IUserRepository repository = new UserRepository(context);
            Guid id = Guid.NewGuid();

            repository.GetById(id);

            context.Received().GetById<UserEntity>(id);
        }


        [Fact]
        public void GetByName_ExistingUser_Found()
        {
            IUserRepository repository = new UserRepository(_context);
            string userName = "Nik";
            var entity = new UserEntity { Id = Guid.NewGuid(), Name = userName };
            _context.AddOrUpdate(entity);

            UserEntity result = repository.GetByName(userName);

            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.Name, result.Name);
        }


        [Fact]
        public void GetByName_NotExistingUser_NotFound()
        {
            IUserRepository repository = new UserRepository(_context);

            UserEntity result = repository.GetByName("Kit");

            Assert.Null(result);
        }


        public void SetFixture(MockContext data)
        {
            _context = new MockContext();
        }
    }
}
