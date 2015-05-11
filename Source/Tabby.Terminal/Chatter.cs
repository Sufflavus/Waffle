using System;

using Microsoft.Practices.Unity;

using Tabby.Terminal.Command;
using Tabby.Terminal.Command.MessageModule;
using Tabby.Terminal.Command.UserModule;
using Tabby.Terminal.Converters;
using Tabby.Terminal.Logger;

using Taddy.BusinessLogic.Models;


namespace Tabby.Terminal
{
    public sealed class Chatter : IDisposable
    {
        private Guid _userId;

        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public NotificationReceiverWrapper NotificationReceiver { get; set; }


        public void Init()
        {
            NotificationReceiver.SubscribeForReceivingMessage(OnMessageReceive);
            NotificationReceiver.SubscribeForReceivingUserState(OnUserStateChanged);
        }


        public void Start()
        {
            _userId = Login();

            Logger.Info("Available commands:");
            Logger.Info("Send: Message text");
            Logger.Info("GetAll");
            Logger.Info("GetNew");

            //var timer = new MessageCheckerTimerWrapper(userId);
            //timer.Start();

            bool hasCommand;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                string commandText = Console.ReadLine();
                hasCommand = !string.IsNullOrEmpty(commandText);
                if (hasCommand)
                {
                    try
                    {
                        MessageCommand command = CommandParser.Parse(commandText);
                        command.UserId = _userId;
                        command.Execute();
                    }
                    catch (ArgumentException)
                    {
                        Logger.Error("Invalid command");
                    }
                    catch (Exception)
                    {
                        Logger.Error("Error occured");
                    }
                }
            }
            while (hasCommand);

            var logoutCommand = Bootstrapper.Resolve<LogoutUserCommand>();
            logoutCommand.UserId = _userId;
            logoutCommand.Execute();

            //timer.Stop();
        }


        public void Dispose()
        {
            Bootstrapper.Dispose();
        }


        private Guid Login()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Guid? userId = null;
            do
            {
                try
                {
                    Logger.Info("Please, enter your NikName: ");
                    string userName = Console.ReadLine();
                    var loginCommand = Bootstrapper.Resolve<LoginUserCommand>();
                    loginCommand.UserName = userName;
                    loginCommand.Execute();
                    userId = loginCommand.Result;
                }
                catch (ArgumentException)
                {
                    Logger.Error("Invalid NikName");
                }
                catch (Exception)
                {
                    Logger.Error("Error occured");
                }
            }
            while (!userId.HasValue);
            return userId.Value;
        }


        private void OnMessageReceive(Message message)
        {
            if (message.RecipientId == _userId)
            {
                Logger.Info("Message has been received: " + message);
            }
        }


        private void OnUserStateChanged(User user)
        {
            if (user.Id != _userId)
            {
                Logger.Info(string.Format("User {0} is now {1}", user, user.IsOnline ? "online" : "offline"));
            }
        }
    }
}
