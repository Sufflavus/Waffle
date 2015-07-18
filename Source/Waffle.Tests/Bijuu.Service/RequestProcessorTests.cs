using System;
using System.Collections.Generic;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Contracts;
using Bijuu.Service;

using NSubstitute;

using Xunit;


namespace Waffle.Tests.Bijuu.Service
{
    public class RequestProcessorTests
    {
        private readonly IMessageManager _messageManager;
        private readonly IRequestProcessor _requestProcessor;
        private readonly IUserManager _userManager;


        public RequestProcessorTests()
        {
            _messageManager = Substitute.For<IMessageManager>();
            _userManager = Substitute.For<IUserManager>();
            _requestProcessor = new RequestProcessor(_messageManager, _userManager);
        }


        [Fact]
        public void GetAllMessages_MessageManager_IsCalled()
        {
            _messageManager.GetAllMessages().Returns(new List<MessageInfo>());

            _requestProcessor.GetAllMessages();

            _messageManager.Received().GetAllMessages();
        }


        [Fact]
        public void GetNewMessages_MessageManager_IsCalled()
        {
            Guid userId = Guid.NewGuid();
            _messageManager.GetNewMessages(userId).Returns(new List<MessageInfo>());

            _requestProcessor.GetNewMessages(userId);

            _messageManager.Received().GetNewMessages(userId);
        }


        [Fact]
        public void GetUserByName_UserManager_IsCalled()
        {
            string userName = "user";
            _userManager.GetUserByName(userName).Returns(new UserInfo());

            _requestProcessor.GetUserByName(userName);

            _userManager.Received().GetUserByName(userName);
        }


        [Fact]
        public void GetUsers_UserManager_IsCalled()
        {
            _requestProcessor.GetUsers();
            _userManager.Received().GetAllUsers();
        }


        [Fact]
        public void LogIn_UserManager_IsCalled()
        {
            string userName = "user";
            var userInfo = new UserInfo();
            _userManager.LogIn(userName).Returns(userInfo);

            _requestProcessor.LogIn(userName);

            _userManager.Received().LogIn(userName);
        }


        [Fact]
        public void LogOut_UserManager_IsCalled()
        {
            var userInfo = new UserInfo { Id = Guid.NewGuid() };

            _requestProcessor.LogOut(userInfo);

            _userManager.Received().LogOut(userInfo.Id);
        }


        [Fact]
        public void SendMessage_MessageManager_IsCalled()
        {
            var message = new MessageInfo { Text = "text", SenderId = Guid.NewGuid() };
            _messageManager.SendMessage(message).Returns(message.Text.Length);

            _requestProcessor.SendMessage(message);

            _messageManager.Received().SendMessage(message);
        }
    }
}
