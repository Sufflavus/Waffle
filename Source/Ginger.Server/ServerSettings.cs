using System;


namespace Ginger.Server
{
    public static class ServerSettings
    {
        public const string HubClassName = "GingerHub";
        public const string ReceiveMessageMethodName = "ReceiveMessage";
        public const string ReceiveUserStateMethodName = "ReceiveUserState";
        public const string SendMessageMethodName = "SendMessage";
        public const string UpdateUserStateMethodName = "UpdateUserState";
    }
}
