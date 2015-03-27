using System;
using System.ServiceModel.Web;

using Bijuu.Service;


namespace Bijuu.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var host = new WebServiceHost(typeof(RequestProcessor)))
            {
                host.Open();
                Console.WriteLine("Service is running");
                Console.WriteLine("Press enter to quit...");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
