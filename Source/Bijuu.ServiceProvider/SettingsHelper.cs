using System;

using Bijuu.ServiceProvider.Properties;


namespace Bijuu.ServiceProvider
{
    public static class SettingsHelper
    {
        public static string ServerAddress
        {
            get { return Settings.Default.ServerAddress; }
        }
    }
}
