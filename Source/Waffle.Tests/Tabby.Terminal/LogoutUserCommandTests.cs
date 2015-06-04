using System;

using NSubstitute;

using Tabby.Terminal.Command.UserModule;
using Tabby.Terminal.Logger;

using Taddy.BusinessLogic.Processor;

using Xunit;


namespace Waffle.Tests.Tabby.Terminal
{
    public class LogoutUserCommandTests
    {
        [Fact]
        public void Execute_UserProcessor_IsCalled()
        {
            var userProcessor = Substitute.For<IUserProcessor>();
            Guid userId = Guid.NewGuid();
            var logger = Substitute.For<ILogger>();
            var command = new LogoutUserCommand { UserProcessor = userProcessor, Logger = logger, UserId = userId };

            command.Execute();

            userProcessor.Received().LogOut(userId);
        }
    }
}
