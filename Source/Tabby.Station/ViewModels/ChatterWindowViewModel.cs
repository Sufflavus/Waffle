using System.Windows.Input;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Station.ViewModels
{
    public sealed class ChatterWindowViewModel : WindowViewModelBase
    {
        private string _newMessageText;


        public ChatterWindowViewModel()
        {
            MessageProcessor = Bootstrapper.Resolve<MessageProcessor>();
        }


        public override string DisplayName
        {
            get { return "Chat room"; }
            protected set { base.DisplayName = value; }
        }

        [Dependency]
        public IMessageProcessor MessageProcessor { get; set; }

        public ICommand SendMessageCommand
        {
            get { return new Command<string>(x => DoSendMessage()); }
        }

        public string NewMessageText
        {
            get { return _newMessageText; }
            set
            {
                _newMessageText = value;
                RaisePropertyChangedEvent("NewMessageText");
            }
        }

        private void DoSendMessage()
        {
            return;

            if (string.IsNullOrEmpty(NewMessageText))
            {
                return;
            }

            Message message = BusinessLogicConverter.ToMessage(NewMessageText);
            //message.SenderId = _userId;
            int result = MessageProcessor.SendMessage(message);
        }
    }
}