using System;

using Growl.Connector;

using Application = System.Windows.Forms.Application;


namespace Tabby.Client
{
    internal class GrowlHelper
    {
        public static void simpleGrowl(string title, string message = "")
        {
            var simpleGrowl = new GrowlConnector();
            var thisApp = new Growl.Connector.Application(Application.ProductName);
            var simpleGrowlType = new NotificationType("SIMPLEGROWL");
            simpleGrowl.Register(thisApp, new NotificationType[] { simpleGrowlType });
            var myGrowl = new Notification(Application.ProductName, "SIMPLEGROWL", title, title, message);
            simpleGrowl.Notify(myGrowl);
        }
    }
}
