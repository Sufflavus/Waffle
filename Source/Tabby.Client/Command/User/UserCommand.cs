using System;

using Tabby.Client.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Command.User
{
    public abstract class UserCommand : ICommand
    {
        public ILogger Logger { get; set; }
        public IUserProcessor UserProcessor { get; set; }
        public abstract void Execute();
    }
}
