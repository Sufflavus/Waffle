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
        private List<User> _onlineUsers;
        private string _recentMessages;
        private Guid _userId;


        public ChatterWindowViewModel()
        {
            _onlineUsers = new List<User>();

            ResolveDependencies();
            ShowOnlineUsers();
            ShowOldMessages(); // TODO: only user's messages
            //Subscribe();

            //TODO: logout
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

        public List<User> OnlineUsers
        {
            get { return _onlineUsers; }
            set
            {
                _onlineUsers = value;
                RaisePropertyChangedEvent("OnlineUsers");
            }
        }

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

        public Guid UserId
        {
            private get { return _userId; }
            set
            {
                _userId = value;
                Subscribe();
            }
        }

        [Dependency]
        public IUserProcessor UserProcessor { get; set; }


        private void AddMessageToRecentMessages(Message message)
        {
            var result = new StringBuilder();
            result.AppendLine(RecentMessages);
            result.AppendLine(message.ToString());
            RecentMessages = result.ToString();
        }


        private void DoSendMessage()
        {
            if (string.IsNullOrEmpty(NewMessageText))
            {
                return;
            }

            Message message = BusinessLogicConverter.ToMessage(NewMessageText);
            message.SenderId = UserId;
            MessageProcessor.SendMessage(message);
            AddMessageToRecentMessages(message);
            //TODO: show error
        }


        private void OnMessageReceive(Message message)
        {
            if (message.RecipientId == UserId)
            {
                AddMessageToRecentMessages(message);
            }
        }


        private void OnUserStateChanged(User user)
        {
            if (user.Id == UserId)
            {
                return;
            }

            if (user.IsOnline && !_onlineUsers.Any(x => x.Id == user.Id))
            {
                _onlineUsers.Add(user);
                return;
            }

            _onlineUsers.RemoveAll(x => x.Id == user.Id);
        }


        private void ResolveDependencies()
        {
            MessageProcessor = Bootstrapper.Resolve<MessageProcessor>();
            UserProcessor = Bootstrapper.Resolve<UserProcessor>();
            NotificationReceiver = Bootstrapper.Resolve<NotificationReceiverWrapper>();
        }


        private void ShowOldMessages()
        {
            List<Message> messages = MessageProcessor.GetAllMessages();
            var result = new StringBuilder();
            if (messages.Any())
            {
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
            IEnumerable<User> users = UserProcessor.GetOnlineUsers();
            OnlineUsers.AddRange(users);
        }


        private void Subscribe()
        {
            NotificationReceiver.RegisterReceiver(UserId);
            NotificationReceiver.SubscribeForReceivingMessage(OnMessageReceive);
            NotificationReceiver.SubscribeForReceivingUserState(OnUserStateChanged);
        }
    }
}
