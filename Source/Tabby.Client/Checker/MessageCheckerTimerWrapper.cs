using System;
using System.Threading;

using Tabby.Client.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client.Checker
{
    public class MessageCheckerTimerWrapper : IDisposable
    {
        private readonly Guid _userId;
        private AutoResetEvent _resetEvent;
        private Timer _timer;


        public MessageCheckerTimerWrapper(Guid userId)
        {
            _userId = userId;
        }


        public ILogger Logger { get; set; }

        public IMessageProcessor MessageProcessor { get; set; }


        public void Start()
        {
            var messageChecker = new MessageChecker(_userId)
            {
                MessageProcessor = MessageProcessor,
                Logger = Logger
            };
            _resetEvent = new AutoResetEvent(false);
            TimerCallback timerCallback = messageChecker.GetNewMessages;
            _timer = new Timer(timerCallback, _resetEvent, 10000, 10000);
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
