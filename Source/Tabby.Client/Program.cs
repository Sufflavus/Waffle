using System;

using Microsoft.Practices.Unity;

using Tabby.Client.Command;
using Tabby.Client.Command.Message;
using Tabby.Client.Command.User;
using Tabby.Client.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client
{
    internal class Program
    {
        //private static readonly ILogger _logger = new NLogLogger();
        private static readonly IMessageProcessor _messageProcessor = new MessageProcessor1();
        private static readonly IUserProcessor _userProcessor = new UserProcessor1();

        [Dependency]
        public static ILogger Logger { get; set; }

        private static Guid Login(IUserProcessor userProcessor)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Guid? userId = null;
            do
            {
                try
                {
                    Logger.Info("Please, enter your NikName: ");
                    string userName = Console.ReadLine();
                    var loginCommand = new LoginUserCommand { UserProcessor = userProcessor, UserName = userName };
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


        private static void Main(string[] args)
        {
            //Bootstrapper.Initialize();
            Logger = Bootstrapper.Resolve<ILogger>();
            //Logger=new NLogLogger();
            //new ChatUi().Start();

            Guid userId = Login(_userProcessor);

            Logger.Info("Available commands:");
            Logger.Info("Send: Message text");
            Logger.Info("GetAll");
            Logger.Info("GetNew");

            /*var timer = new MessageCheckerTimerWrapper(userId)
            {
                MessageProcessor = _messageProcessor, 
                Logger = _logger
            };
            timer.Start();*/

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
                        command.MessageProcessor = _messageProcessor;
                        //command.Logger = Logger;
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

            var logoutCommand = new LogoutUserCommand { UserProcessor = _userProcessor, UserId = userId };
            logoutCommand.Execute();

            //timer.Stop();
        }
    }
}
