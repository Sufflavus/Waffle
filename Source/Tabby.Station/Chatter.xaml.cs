using System;
using System.Windows;


namespace Tabby.Station
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Chatter : Window
    {
        public Chatter()
        {
            InitializeComponent();
        }


        private void Chatter_Loaded(object sender, RoutedEventArgs e)
        {
            TbRecentMessages.Text = "Hello!";
        }
    }
}
