using System;

using Microsoft.Practices.Unity;

using Tabby.Terminal.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Terminal.Command.UserModule
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
