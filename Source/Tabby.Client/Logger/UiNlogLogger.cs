using System;

using NLog;


namespace Tabby.Client.Logger
{
    public class UiNlogLogger : ILogger
    {
        private static readonly NLog.Logger _instance;


        static UiNlogLogger()
        {
            LogManager.ReconfigExistingLoggers();
            _instance = LogManager.GetCurrentClassLogger();
            //http://www.codeproject.com/Articles/786304/Logging-How-to-Growl-with-NLog-or
        }


        public void Error(string message)
        {
            _instance.Error(message);
        }


        public void Info(string message)
        {
            _instance.Info(message);
        }


        public void Trace(string message)
        {
            _instance.Trace(message);
        }
    }
}
