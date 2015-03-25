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
