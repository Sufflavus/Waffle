using System;

using Microsoft.Practices.Unity;

using Tabby.Client.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Command.User
{
    public abstract class UserCommand : ICommand
    {
        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public IUserProcessor UserProcessor { get; set; }

        public abstract void Execute();
    }
}
