using System;
using System.Configuration;


namespace Tabby.Dal
{
    public static class ConnectionManagerHelper
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Tabby"].ConnectionString; }
        }
    }
}
