using System;
using System.Collections.Generic;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using NSubstitute;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;

using Xunit;


namespace Waffle.Tests.Taddy.BusinessLogic
{
    public class UserProcessorTests
    {
        private readonly IBijuuServiceClient _serviceClient;
        private readonly IUserProcessor _userProcessor;


        public UserProcessorTests()
        {
            _serviceClient = Substitute.For<IBijuuServiceClient>();
            _userProcessor = new UserProcessor { ServiceClient = _serviceClient };
        }


        [Fact]
        public void GetUserByName_ServiceClient_IsCalled()
        {
            string userName = "user";
            var userInfo = new UserInfo { Name = userName };
            _serviceClient.GetUserByName(userName).Returns(userInfo);

            _userProcessor.GetUserByName(userName);

            _serviceClient.Received().GetUserByName(userName);
        }


        [Fact]
        public void GetOnlineUsers_ServiceClient_IsCalled()
        {
            var users = new List<UserInfo> { new UserInfo { Name = "user" } };
            _serviceClient.GetUsers().Returns(users);

            _userProcessor.GetOnlineUsers();

            _serviceClient.Received().GetUsers();
        }

        [Fact]
        public void GetOnlineUsers_CorrectResult()
        {
            var user1 = new UserInfo { Name = "user1", IsOnline = true };
            var user2 = new UserInfo { Name = "user2", IsOnline = false };
            var users = new List<UserInfo> { user1, user2 };
            _serviceClient.GetUsers().Returns(users);

            List<User> result = _userProcessor.GetOnlineUsers();

            Assert.Equal(result.Count, 1);
            Assert.Equal(result[0].Name, user1.Name);
            Assert.True(result[0].IsOnline);
        }


        [Fact]
        public void LogIn_CorrectResult()
        {
            string userName = "user";
            var userForLogin = new User { Id = Guid.NewGuid(), Name = userName };
            var userInfo = new UserInfo { Id = Guid.NewGuid(), Name = userName };
            _serviceClient.LogIn(userName).Returns(userInfo);

            _userProcessor.LogIn(userForLogin);

            Assert.Equal(userInfo.Id, userForLogin.Id);
            Assert.Equal(userInfo.Name, userForLogin.Name);
        }


        [Fact]
        public void LogIn_ServiceClient_IsCalled()
        {
            string userName = "user";
            var userInfo = new UserInfo { Name = userName };
            _serviceClient.LogIn(userName).Returns(userInfo);

            _userProcessor.LogIn(new User { Name = userName });

            _serviceClient.Received().LogIn(userName);
        }


        [Fact]
        public void LogOut_ServiceClient_IsCalled()
        {
            Guid userId = Guid.NewGuid();

            _userProcessor.LogOut(userId);

            _serviceClient.Received().LogOut(userId);
        }
    }
}
