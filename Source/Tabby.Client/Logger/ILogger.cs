using System;


namespace Tabby.Client.Logger
{
    public interface ILogger
    {
        void Error(string message);
        void Info(string message);
        void Trace(string message);
    }
}
