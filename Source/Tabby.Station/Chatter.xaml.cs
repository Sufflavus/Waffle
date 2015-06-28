using System;
using System.Windows;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;
using Taddy.BusinessLogic.Converters;


namespace Tabby.Station
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Chatter : Window
    {
        private Guid _userId;

        [Dependency]
        public IMessageProcessor MessageProcessor { get; set; }

        public Chatter()
        {
            InitializeComponent();
        }


        private void Chatter_Loaded(object sender, RoutedEventArgs e)
        {
            TbRecentMessages.Text = "Hello!";
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
