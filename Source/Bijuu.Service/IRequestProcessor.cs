using System;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace Bijuu.Service
{
    [ServiceContract]
    public interface IRequestProcessor
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetAllMessages?message={message}")]
        void GetAllMessages(string message);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetNewMessages?userId={userId}")]
        void GetNewMessages(Guid userId);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/LogIn?userName={userName}")]
        Guid LogIn(string userName);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/LogOut?userId={userId}")]
        void LogOut(Guid userId);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SendMessage?message={message}")]
        int SendMessage(string message);
    }
}
