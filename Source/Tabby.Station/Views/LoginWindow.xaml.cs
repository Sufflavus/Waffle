using System;
using System.Windows;

using Tabby.Station.ViewModels;


namespace Tabby.Station.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            (DataContext as WindowViewModelBase).RequestClose += (sender, args) => Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
