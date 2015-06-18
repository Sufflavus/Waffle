using System;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Contracts;
using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository.Interfaces;

using Ginger.Notifier;

using NSubstitute;

using Xunit;


namespace Waffle.Tests.Bijuu.BusinessLogic
{
    public class UserManagerTests : IUseFixture<MockUserRepository>
    {
        private MockUserRepository _repository;
        private IUserManager _userManager;


        [Fact]
        public void GetUserByName_ExistingUser_CorrectUserInfo()
        {
            var repository = Substitute.For<IUserRepository>();
            IUserManager manager = new UserManager { Repository = repository };
            string userName = "user";
            var user = new UserEntity { Id = Guid.NewGuid(), Name = userName, IsOnline = false };
            repository.GetByName(userName).Returns(user);

            UserInfo result = manager.GetUserByName(userName);

            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
        }


        [Fact]
        public void GetUserByName_GetByNameCalledInRepository()
        {
            var repository = Substitute.For<IUserRepository>();
            IUserManager manager = new UserManager { Repository = repository };
            string userName = "user";
            var user = new UserEntity { Id = Guid.NewGuid(), Name = userName, IsOnline = false };
            repository.GetByName(userName).Returns(user);

            manager.GetUserByName(userName);

            repository.Received().GetByName(userName);
        }


        [Fact]
        public void GetUserByName_NotExistingUser_Null()
        {
            var repository = Substitute.For<IUserRepository>();
            IUserManager manager = new UserManager { Repository = repository };
            string userName = "user";
            UserEntity user = null;
            repository.GetByName(userName).Returns(user);

            UserInfo result = manager.GetUserByName(userName);

            Assert.Null(result);
        }


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
        public void LogIn_GetByNameCalledInRepository()
        {
            var repository = Substitute.For<IUserRepository>();
            var notificationSender = Substitute.For<INotificationSender>();
            IUserManager manager = new UserManager { Repository = repository, NotificationSender = notificationSender };
            string userName = "user";
            var user = new UserEntity { Id = Guid.NewGuid(), Name = userName, IsOnline = false };
            repository.GetByName(userName).Returns(user);

            manager.LogIn(userName);

            repository.Received().GetByName(userName);
            repository.Received().AddOrUpdate(user);
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
        public void LogOut_ExistingOnlineUser_SettedOffline()
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
            var notificationSender = Substitute.For<INotificationSender>();
            IUserManager manager = new UserManager { Repository = repository, NotificationSender = notificationSender };
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
            var notificationSender = Substitute.For<INotificationSender>();
            _userManager = new UserManager { Repository = _repository, NotificationSender = notificationSender };
        }
    }
}
