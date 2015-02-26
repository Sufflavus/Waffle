using System;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class UserProcessor1 : IUserProcessor
    {
        private readonly IBijuuServiceClient _serviceClient;


        public UserProcessor1()
        {
            _serviceClient = new BijuuServiceClient();
        }


        public UserProcessor1(IBijuuServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }


        public void LogIn(User user)
        {
            UserInfo userInfo = _serviceClient.LogIn(user.Name);
            user.Id = userInfo.Id;
        }


        public void LogOut(Guid userId)
        {
            _serviceClient.LogOut(userId);
        }
    }
}
