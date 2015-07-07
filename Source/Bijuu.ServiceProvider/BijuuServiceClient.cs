using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Bijuu.Contracts;

using Newtonsoft.Json;


namespace Bijuu.ServiceProvider
{
    public class BijuuServiceClient : IBijuuServiceClient
    {
        private const string JsonMediaType = "application/json";


        public List<MessageInfo> GetAllMessages()
        {
            string uri = UrlAddressFactory.GetAllMessages();
            var data = GetData<List<MessageInfo>>(uri);
            return data;
        }


        public List<MessageInfo> GetNewMessages(Guid userId)
        {
            string uri = UrlAddressFactory.GetNewMessages(userId);
            var data = GetData<List<MessageInfo>>(uri);
            return data;
        }


        public UserInfo GetUserByName(string userName)
        {
            string uri = UrlAddressFactory.GetUserByName(userName);
            var data = GetData<UserInfo>(uri);
            return data;
        }


        public List<UserInfo> GetUsers()
        {
            string uri = UrlAddressFactory.GetUsers();
            var data = GetData<List<UserInfo>>(uri);
            return data;
        }


        public UserInfo LogIn(string userName)
        {
            string uri = UrlAddressFactory.LogIn(userName);
            var data = GetData<UserInfo>(uri);
            return data;
        }


        public void LogOut(Guid userId)
        {
            string uri = UrlAddressFactory.LogOut();
            var userInfo = new UserInfo
            {
                Id = userId,
                Name = "name",
                IsOnline = false
            };
            string jsonPostData = JsonConvert.SerializeObject(userInfo);
            PostData(uri, jsonPostData);
        }


        public int SendMessage(string message, Guid senderId)
        {
            string uri = UrlAddressFactory.SendMessage();
            var messageInfo = new MessageInfo
            {
                Id = null,
                SenderId = senderId,
                Text = message,
                IsDelivered = false,
                CreateDate = null,
            };
            string jsonPostData = JsonConvert.SerializeObject(messageInfo);
            PostData(uri, jsonPostData);
            return message.Length;
        }


        public int SendMessageToUser(MessageInfo message)
        {
            string uri = UrlAddressFactory.SendMessageToUser();
            string jsonPostData = JsonConvert.SerializeObject(message);
            PostData(uri, jsonPostData);
            return message.Text.Length;
        }


        private T GetData<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                using (Task<HttpResponseMessage> task = client.GetAsync(uri))
                {
                    HttpResponseMessage response = task.Result;
                    Task<string> jsonResult = response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(jsonResult.Result);
                    return result;
                }
            }
        }


        private bool PostData(string uri, string jsonPostData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);

                var requestContent = new StringContent(jsonPostData, Encoding.UTF8, JsonMediaType);

                using (Task<HttpResponseMessage> task = client.PostAsync(uri, requestContent))
                {
                    task.Result.EnsureSuccessStatusCode();
                    return true;
                }
            }
        }
    }
}
