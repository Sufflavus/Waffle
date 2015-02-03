using System;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Models;

using Xunit;


namespace Tabby.Tests.Taddy.BusinessLogic
{
    public class UserProcessorTests : IUseFixture<MockUserRepository>
    {
        private MockUserRepository _repository;
        private IUserProcessor _userProcessor;


        [Fact]
        public void LogIn_ExistingOfflineUser_Online()
        {
            var user1 = new UserEntity { Id = Guid.NewGuid(), Name = "user1", IsOnline = false };
            var user2 = new UserEntity { Id = Guid.NewGuid(), Name = "user2", IsOnline = false };

            _repository.AddOrUpdate(user1);
            _repository.AddOrUpdate(user2);
            int itemsCount = _repository.Storage.Count;

            var userForLogin = new User { Name = user1.Name };

            _userProcessor.LogIn(userForLogin);

            Assert.True(user1.IsOnline);
            Assert.Equal(userForLogin.Id, user1.Id);
            Assert.Equal(_repository.Storage.Count, itemsCount);
        }


        [Fact]
        public void LogIn_NotExistingUser_UserAdded()
        {
            int itemsCount = _repository.Storage.Count;

            _userProcessor.LogIn(new User { Name = "newUser" });

            Assert.Equal(_repository.Storage.Count, itemsCount + 1);
            BaseEntity actual = _repository.Storage[0];
            Assert.True(((UserEntity)actual).IsOnline);
        }


        [Fact]
        public void LogOut_ExistingOnlineUser_Offline()
        {
            var user1 = new UserEntity { Id = Guid.NewGuid(), Name = "user1", IsOnline = true };
            var user2 = new UserEntity { Id = Guid.NewGuid(), Name = "user2", IsOnline = true };

            _repository.AddOrUpdate(user1);
            _repository.AddOrUpdate(user2);

            _userProcessor.LogOut(user1.Id);

            Assert.False(user1.IsOnline);
            Assert.True(user2.IsOnline);
        }


        [Fact]
        public void LogOut_NotExistingUser_Throws()
        {
            Exception result = Assert.Throws<ArgumentException>(() => _userProcessor.LogOut(Guid.NewGuid()));

            Assert.IsType(typeof(ArgumentException), result);
        }


        public void SetFixture(MockUserRepository data)
        {
            _repository = new MockUserRepository();
            _userProcessor = new UserProcessor(_repository);
        }
    }
}
