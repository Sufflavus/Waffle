﻿using System;
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
