using System;

using NLog;


namespace Tabby.Client.Logger
{
    public class NLogLogger : ILogger
    {
        private static readonly NLog.Logger _instance;


        static NLogLogger()
        {
            LogManager.ReconfigExistingLoggers();
            /*var config = new LoggingConfiguration();
            var growlTarget = new NLog.Targets.GrowlNotify();
            config.AddTarget("growl", growlTarget);
            growlTarget.Port = 23053;
            var rule = new LoggingRule("Test.*", LogLevel.Trace, growlTarget);
            config.LoggingRules.Add(rule);
            LogManager.Configuration = config;*/
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
