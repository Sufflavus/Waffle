using System;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Contracts;

using NSubstitute;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;

using Xunit;


namespace Waffle.Tests.Bijuu.BusinessLogic
{
    public class UserManagerTests : IUseFixture<MockUserRepository>
    {
        private MockUserRepository _repository;
        private IUserManager _userManager;


        [Fact]
        public void LogIn_ExistingOfflineUser_Online()
        {
            var user1 = new UserEntity { Id = Guid.NewGuid(), Name = "user1", IsOnline = false };
            var user2 = new UserEntity { Id = Guid.NewGuid(), Name = "user2", IsOnline = false };

            _repository.AddOrUpdate(user1);
            _repository.AddOrUpdate(user2);
            int itemsCount = _repository.Storage.Count;

            UserInfo result = _userManager.LogIn(user1.Name);

            Assert.True(result.IsOnline);
            Assert.True(user1.IsOnline);
            Assert.Equal(user1.Id, result.Id);
            Assert.Equal(_repository.Storage.Count, itemsCount);
        }


        [Fact]
        public void LogIn_NotExistingUser_UserAdded()
        {
            int itemsCount = _repository.Storage.Count;

            UserInfo result = _userManager.LogIn("newUser");

            Assert.Equal(_repository.Storage.Count, itemsCount + 1);
            Assert.True(result.IsOnline);
            BaseEntity actual = _repository.Storage[0];
            Assert.True(((UserEntity)actual).IsOnline);
        }


        [Fact]
        public void LogIn__GetByNameCalledInRepository()
        {
            var repository = Substitute.For<IUserRepository>();
            IUserManager manager = new UserManager(repository);
            string userName = "user";
            var user = new UserEntity { Id = Guid.NewGuid(), Name = userName, IsOnline = false };
            repository.GetByName(userName).Returns(user);

            manager.LogIn(userName);

            repository.Received().GetByName(userName);
            repository.Received().AddOrUpdate(user);
        }


        [Fact]
        public void LogOut_ExistingOnlineUser_Offline()
        {
            var user1 = new UserEntity { Id = Guid.NewGuid(), Name = "user1", IsOnline = true };
            var user2 = new UserEntity { Id = Guid.NewGuid(), Name = "user2", IsOnline = true };

            _repository.AddOrUpdate(user1);
            _repository.AddOrUpdate(user2);

            _userManager.LogOut(user1.Id);

            Assert.False(user1.IsOnline);
            Assert.True(user2.IsOnline);
        }


        [Fact]
        public void LogOut_NotExistingUser_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => _userManager.LogOut(Guid.NewGuid()));

            Assert.IsType(typeof(ArgumentException), result);
        }


        [Fact]
        public void LogOut__GetByIdCalledInRepository()
        {
            var repository = Substitute.For<IUserRepository>();
            IUserManager manager = new UserManager(repository);
            Guid userId = Guid.NewGuid();
            var user = new UserEntity { Id = userId, Name = "user", IsOnline = true };
            repository.GetById(userId).Returns(user);

            manager.LogOut(userId);

            repository.Received().GetById(userId);
            repository.Received().AddOrUpdate(user);
            Assert.False(user.IsOnline);
        }


        public void SetFixture(MockUserRepository data)
        {
            _repository = new MockUserRepository();
            _userManager = new UserManager(_repository);
        }
    }
}
