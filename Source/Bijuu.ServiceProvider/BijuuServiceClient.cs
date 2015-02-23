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
    }
}
