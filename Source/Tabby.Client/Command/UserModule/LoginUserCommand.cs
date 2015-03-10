using System;

using Taddy.BusinessLogic.Models;


namespace Tabby.Client.Command.UserModule
{
    public class LoginUserCommand : UserCommand
    {
        public Guid Result { get; set; }
        public string UserName { get; set; }


        public override void Execute()
        {
            User user = BusinessLogicConverter.ToUser(UserName);
            UserProcessor.LogIn(user);
            Result = user.Id;

            Logger.Trace(string.Format("User '{0}' has been logged in. UserId: {1}", UserName, user.Id));
        }
    }
}
