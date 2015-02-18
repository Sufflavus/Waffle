using System;


namespace Tabby.Client.Command.User
{
    public class LoginUserCommand : UserCommand
    {
        public Guid Result { get; set; }
        public string UserName { get; set; }


        public override void Execute()
        {
            Taddy.BusinessLogic.Models.User user = BusinessLogicConverter.ToUser(UserName);
            UserProcessor.LogIn(user);
            Result = user.Id;

            Logger.Trace(string.Format("User '{0}' has been logged in. UserId: {1}", UserName, user.Id));
        }
    }
}
