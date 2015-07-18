using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using Bijuu.Contracts;


namespace Bijuu.Service
{
    [ServiceContract]
    public interface IRequestProcessor
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetAllMessages")]
        List<MessageInfo> GetAllMessages();


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetNewMessages?userId={userId}")]
        List<MessageInfo> GetNewMessages(Guid userId);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUserByName?userName={userName}")]
        UserInfo GetUserByName(string userName);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUsers")]
        List<UserInfo> GetUsers();


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/LogIn?userName={userName}")]
        UserInfo LogIn(string userName);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LogOut")]
        void LogOut(UserInfo user);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/SendMessage")]
        void SendMessage(MessageInfo message);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/SendMessageToUser")]
        void SendMessageToUser(MessageInfo message);
    }
}
