using System;

using Ginger.Server.Properties;

using Microsoft.Owin.Hosting;


namespace Ginger.Server
{
    internal class Program
    {
        //http://www.asp.net/signalr/overview/deployment/tutorial-signalr-self-host
        //http://stackoverflow.com/questions/11140164/signalr-console-app-example
        //http://www.codeproject.com/Articles/804770/Implementing-SignalR-in-Desktop-Applications
        //http://www.asp.net/signalr/overview/guide-to-the-api/hubs-api-guide-net-client
        private static void Main(string[] args)
        {
            using (WebApp.Start(Settings.Default.ServiceUrl))
            {
                Console.WriteLine("Server running on {0}", Settings.Default.ServiceUrl);
                Console.ReadLine();
            }
        }
    }
}
