using System;


namespace Tabby.Terminal.Command.UserModule
{
    public class LogoutUserCommand : UserCommand
    {
        public Guid UserId { get; set; }


        public override void Execute()
        {
            UserProcessor.LogOut(UserId);
        }
    }
}
