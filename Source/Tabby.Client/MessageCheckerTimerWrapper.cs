using System;
using System.Threading;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    public class MessageCheckerTimerWrapper : IDisposable
    {
        private readonly IMessageProcessor _messageProcessor;
        private AutoResetEvent _resetEvent;
        private Timer _timer;


        public MessageCheckerTimerWrapper(IMessageProcessor messageProcessor)
        {
            _messageProcessor = messageProcessor;
        }


        public void Start()
        {
            var messageChecker = new MessageChecker(_messageProcessor);
            _resetEvent = new AutoResetEvent(false);
            TimerCallback timerCallback = messageChecker.GetMessages;
            _timer = new Timer(timerCallback, _resetEvent, 10000, 250);
        }


        public void Stop()
        {
            Dispose();
        }


        public void Dispose()
        {
            if (_timer != null)
            {
                _resetEvent.Set();
                _timer.Dispose();
            }
        }
    }
}
