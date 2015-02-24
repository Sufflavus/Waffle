using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Bijuu.Contracts;

using Newtonsoft.Json;


namespace Bijuu.ServiceProvider
{
    public class BijuuServiceClient : IBijuuServiceClient
    {
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


        public Guid LogIn(string userName)
        {
            string uri = UrlAddressFactory.LogIn(userName);
            var data = GetData<Guid>(uri);
            return data;
        }


        public void LogOut(Guid userId)
        {
            string uri = UrlAddressFactory.LogOut(userId);
            GetData<Guid>(uri); // POST?
        }


        public int SendMessage(string message)
        {
            string uri = UrlAddressFactory.SendMessage();
            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message", message)
            };
            //return PostData(uri, data);
            PostData(uri, data);
            return message.Length;
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


        private bool PostData(string uri, List<KeyValuePair<string, string>> postData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                HttpContent content = new FormUrlEncodedContent(postData);

                using (Task<HttpResponseMessage> task = client.PostAsync(uri, content))
                {
                    task.Result.EnsureSuccessStatusCode();
                    return true;
                }
            }
        }
    }
}
