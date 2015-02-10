using System;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Command.User
{
    public abstract class UserCommand : ICommand
    {
        public IUserProcessor UserProcessor { get; set; }
        public abstract void Execute();
    }
}
