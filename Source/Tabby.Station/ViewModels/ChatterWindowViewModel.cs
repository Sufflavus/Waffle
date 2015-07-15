using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Station.ViewModels
{
    public sealed class ChatterWindowViewModel : WindowViewModelBase
    {
        private string _newMessageText;
        private string _recentMessages;


        public ChatterWindowViewModel()
        {
            MessageProcessor = Bootstrapper.Resolve<MessageProcessor>();
            NotificationReceiver = Bootstrapper.Resolve<NotificationReceiverWrapper>();
            ShowOnlineUsers();
            ShowOldMessages();
            Subscribe();
        }


        public override string DisplayName
        {
            get { return "Chat room"; }
            protected set { base.DisplayName = value; }
        }

        [Dependency]
        public IMessageProcessor MessageProcessor { get; set; }

        public string NewMessageText
        {
            get { return _newMessageText; }
            set
            {
                _newMessageText = value;
                RaisePropertyChangedEvent("NewMessageText");
            }
        }

        [Dependency]
        public NotificationReceiverWrapper NotificationReceiver { get; set; }

        public string RecentMessages
        {
            get { return _recentMessages; }
            set
            {
                _recentMessages = value;
                RaisePropertyChangedEvent("RecentMessages");
            }
        }

        public ICommand SendMessageCommand
        {
            get { return new Command<string>(x => DoSendMessage()); }
        }

        public Guid UserId { private get; set; }

        [Dependency]
        public IUserProcessor UserProcessor { get; set; }


        private void DoSendMessage()
        {
            if (string.IsNullOrEmpty(NewMessageText))
            {
                return;
            }

            Message message = BusinessLogicConverter.ToMessage(NewMessageText);
            message.SenderId = UserId;
            int result = MessageProcessor.SendMessage(message);
        }


        private void OnMessageReceive(Message message)
        {
            if (message.RecipientId == UserId)
            {
                var result = new StringBuilder();
                result.AppendLine(RecentMessages);
                result.AppendLine(message.ToString());
                RecentMessages = result.ToString();
            }
        }


        private void OnUserStateChanged(User user)
        {
            if (user.Id == UserId)
            {
                return;
            }
            /*if (user.IsOnline && !_onlineUsers.Contains(user.Name))
            {
                _onlineUsers.Add(user.Name);
            }
            else if (_onlineUsers.Contains(user.Name))
            {
                _onlineUsers.Remove(user.Name);
            }*/
        }


        private void ShowOldMessages()
        {
            List<Message> messages = MessageProcessor.GetAllMessages();
            var result = new StringBuilder();
            if (messages.Any())
            {
                result.AppendLine("All messages:");
                messages.ForEach(x => result.AppendLine(x.ToString()));
            }
            else
            {
                result.AppendLine("There is not any message");
            }

            RecentMessages = result.ToString();
        }


        private void ShowOnlineUsers()
        {
            /*IEnumerable<string> users = UserProcessor.GetOnlineUsers().Select(x => x.Name);
            _onlineUsers.AddRange(users);
            LvUsers.ItemsSource = _onlineUsers;*/
        }


        private void Subscribe()
        {
            //NotificationReceiver.RegisterReceiver(UserId);
            NotificationReceiver.RegisterReceiver(Guid.NewGuid()); // FAKE
            NotificationReceiver.SubscribeForReceivingMessage(OnMessageReceive);
            NotificationReceiver.SubscribeForReceivingUserState(OnUserStateChanged);
        }
    }
}
