using System;
using System.Threading;

using Microsoft.Practices.Unity;


namespace Tabby.Client.Checker
{
    public class MessageCheckerTimerWrapper : IDisposable
    {
        private readonly MessageChecker _messageChecker;
        private AutoResetEvent _resetEvent;
        private Timer _timer;


        public MessageCheckerTimerWrapper(Guid userId)
        {
            _messageChecker = Bootstrapper.Resolve<MessageChecker>(new ParameterOverride("userId", userId));
        }


        public void Start()
        {
            _resetEvent = new AutoResetEvent(false);
            TimerCallback timerCallback = _messageChecker.GetNewMessages;
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
