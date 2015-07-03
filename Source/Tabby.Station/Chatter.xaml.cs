using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Station
{
    /// <summary>
    /// Interaction logic for Chatter.xaml
    /// </summary>
    public partial class Chatter : Window
    {
        private readonly Guid _userId;


        public Chatter(Guid userId)
        {
            _userId = userId;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }


        [Dependency]
        public IMessageProcessor MessageProcessor { get; set; }

        [Dependency]
        public NotificationReceiverWrapper NotificationReceiver { get; set; }

        [Dependency]
        public IUserProcessor UserProcessor { get; set; }


        private void Chatter_Loaded(object sender, RoutedEventArgs e)
        {
            List<Message> messages = MessageProcessor.GetAllMessages();
            ShowOldMessages(messages);
            Subscribe();

            var onlineUsers = new List<string> { "user 1", "user 1" };
            LvUsers.ItemsSource = onlineUsers;
        }


        private void OnMessageReceive(Message message)
        {
            if (message.RecipientId == _userId)
            {
                //TODO
            }
        }


        private void OnUserStateChanged(User user)
        {
            if (user.Id != _userId)
            {
                //TODO
            }
        }


        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string messageText = TbNewMessage.Text;
            if (string.IsNullOrEmpty(messageText))
            {
                return;
            }

            Message message = BusinessLogicConverter.ToMessage(messageText);
            message.SenderId = _userId;
            int result = MessageProcessor.SendMessage(message);
        }


        private void ShowOldMessages(List<Message> messages)
        {
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

            TbRecentMessages.Text = result.ToString();
        }


        private void Subscribe()
        {
            NotificationReceiver.RegisterReceiver(_userId);
            NotificationReceiver.SubscribeForReceivingMessage(OnMessageReceive);
            NotificationReceiver.SubscribeForReceivingUserState(OnUserStateChanged);
        }
    }
}
