using System;


namespace Bijuu.ServiceProvider
{
    public static class Terms
    {
        public const string GetAllMessages = "/GetAllMessages";
        public const string GetNewMessages = "/GetNewMessages?userId={0}";
        public const string LogIn = "/LogIn?userName={0}";
        public const string LogOut = "/LogOut?userId={0}";
        public const string SendMessage = "/SendMessage";
    }
}
