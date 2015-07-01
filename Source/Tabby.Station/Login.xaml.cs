using System;
using System.Windows;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Station
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        /*
         How to enable a button when a user types into a textbox
         http://stackoverflow.com/questions/821121/how-to-enable-a-button-when-a-user-types-into-a-textbox
         */


        public Login()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }


        [Dependency]
        public IUserProcessor UserProcessor { get; set; }


        private Guid GetUserId(string userName)
        {
            User user = BusinessLogicConverter.ToUser(userName);
            UserProcessor.LogIn(user);
            return user.Id;
            //return Guid.NewGuid();
        }


        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string userName = tbLogin.Text;
            if (string.IsNullOrEmpty(userName))
            {
                return;
            }

            Guid userId;

            try
            {
                userId = GetUserId(userName);
            }
            catch (ArgumentException)
            {
                lbError.Content = "Invalid NikName";
                return;
            }
            catch (Exception)
            {
                lbError.Content = "Error occured";
                return;
            }

            var chatter = new Chatter(userId);
            chatter.Show();
            Close();
        }
    }
}
