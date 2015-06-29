using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Station
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Chatter : Window
    {
        private Guid _userId;


        public Chatter()
        {
            InitializeComponent();
        }


        [Dependency]
        public IMessageProcessor MessageProcessor { get; set; }


        private void Chatter_Loaded(object sender, RoutedEventArgs e)
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
            TbRecentMessages.Text = result.ToString();
        }


        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string messageText = TbMessageText.Text;
            Message message = BusinessLogicConverter.ToMessage(messageText);
            message.SenderId = _userId;
            int result = MessageProcessor.SendMessage(message);
        }
    }
}
