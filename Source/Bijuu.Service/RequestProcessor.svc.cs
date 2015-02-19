using System;


namespace Bijuu.Service
{
    public class RequestProcessor : IRequestProcessor
    {
        public void GetAllMessages(string message)
        {
            throw new NotImplementedException();
        }


        public void GetNewMessages(Guid userId)
        {
            throw new NotImplementedException();
        }


        public Guid LogIn(string userName)
        {
            throw new NotImplementedException();
        }


        public void LogOut(Guid userId)
        {
            throw new NotImplementedException();
        }


        public int SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
