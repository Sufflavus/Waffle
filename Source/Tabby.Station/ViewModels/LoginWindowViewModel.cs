using System;
using System.Windows.Input;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Station.ViewModels
{
    public class LoginWindowViewModel : WindowViewModelBase
    {
        private string _errorMessage = string.Empty;
        private string _userName;


        public LoginWindowViewModel()
        {
            UserProcessor = Bootstrapper.Resolve<UserProcessor>();
        }


        public override string DisplayName
        {
            get { return "Login"; }
            protected set { base.DisplayName = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChangedEvent("ErrorMessage");
            }
        }

        public ICommand LogInCommand
        {
            get { return new Command<string>(x => DoLogin()); }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChangedEvent("UserName");
            }
        }

        [Dependency]
        public IUserProcessor UserProcessor { get; set; }


        private void DoLogin()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserName.Trim()))
            {
                ErrorMessage = "User name can't be empty";
            }

            Guid userId;

            try
            {
                userId = GetUserId(UserName);
                //TODO: open login window
                RaiseRequestClose();
            }
            catch (ArgumentException)
            {
                ErrorMessage = "Invalid NikName";
                return;
            }
            catch (Exception)
            {
                ErrorMessage = "Error occured";
                return;
            }
        }


        private Guid GetUserId(string userName)
        {
            User user = BusinessLogicConverter.ToUser(userName);
            UserProcessor.LogIn(user);
            return user.Id;
            //return Guid.NewGuid();
        }
    }
}
