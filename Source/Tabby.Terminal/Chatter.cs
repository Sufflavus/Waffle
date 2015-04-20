using System;

using Ginger.Notifier;
using Ginger.Contracts;

using Microsoft.Practices.Unity;

using Tabby.Terminal.Checker;
using Tabby.Terminal.Command;
using Tabby.Terminal.Command.MessageModule;
using Tabby.Terminal.Command.UserModule;
using Tabby.Terminal.Logger;


namespace Tabby.Terminal
{
    public sealed class Chatter : IDisposable
    {
        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public INotificationReceiver NotificationReceiver { get; set; }


        public void Init()
        {
            NotificationReceiver.SubscribeForReceivingMessage(x => Logger.Info("Message has been received: " + x.Text));
            NotificationReceiver.SubscribeForReceivingUserState(x => Logger.Info("Message has been received: " + x.Name));
        }


        public void Start()
        {
            Guid userId = Login();

            Logger.Info("Available commands:");
            Logger.Info("Send: Message text");
            Logger.Info("GetAll");
            Logger.Info("GetNew");

            var timer = new MessageCheckerTimerWrapper(userId);
            timer.Start();

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
                        command.UserId = userId;
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
            logoutCommand.UserId = userId;
            logoutCommand.Execute();

            timer.Stop();
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
    }
}
