using System;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;

using Xunit;


namespace Tabby.Tests.Tabby.Dal.Repository
{
    public class UserRepositoryTests : IUseFixture<MockContext>
    {
        private MockContext _context;


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
