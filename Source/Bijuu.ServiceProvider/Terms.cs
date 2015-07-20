using System;


namespace Bijuu.ServiceProvider
{
    public static class Terms
    {
        public const string GetAllMessages = "/GetAllMessages";
        public const string GetNewMessages = "/GetNewMessages?userId={0}";
        public const string GetUserByName = "/GetUserByName?userName={0}";
        public const string GetUserMessages = "/GetUserMessages?userId={0}";
        public const string GetUsers = "/GetUsers";
        public const string LogIn = "/LogIn?userName={0}";
        public const string LogOut = "/LogOut";
        public const string SendMessage = "/SendMessage";
        public const string SendMessageToUser = "/SendMessageToUser";
    }
}
