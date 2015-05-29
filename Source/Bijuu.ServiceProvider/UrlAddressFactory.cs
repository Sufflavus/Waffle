using System;
using System.IO;


namespace Bijuu.ServiceProvider
{
    public static class UrlAddressFactory
    {
        private static readonly string _baseUri = SettingsHelper.ServerAddress;


        public static string GetAllMessages()
        {
            return CreateUri(Terms.GetAllMessages);
        }


        public static string GetNewMessages(Guid userId)
        {
            return CreateUri(string.Format(Terms.GetNewMessages, userId));
        }


        public static string GetUserByName(string userName)
        {
            return CreateUri(string.Format(Terms.GetUserByName, userName));
        }


        public static string LogIn(string userName)
        {
            return CreateUri(string.Format(Terms.LogIn, userName));
        }


        public static string LogOut()
        {
            return CreateUri(Terms.LogOut);
        }


        public static string SendMessage()
        {
            return CreateUri(Terms.SendMessage);
        }


        private static string CreateUri(string relativeUrl)
        {
            return UrlPathCombine(_baseUri, relativeUrl);
        }


        private static string UrlPathCombine(string path1, string path2)
        {
            path1 = path1.TrimEnd('/') + "/";
            path2 = path2.TrimStart('/');

            return Path.Combine(path1, path2)
                .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }
    }
}
