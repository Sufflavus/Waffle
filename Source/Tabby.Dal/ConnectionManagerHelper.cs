using System;
using System.Configuration;


namespace Bijuu.Dal
{
    public static class ConnectionManagerHelper
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Tabby"].ConnectionString; }
        }
    }
}
