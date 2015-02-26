using System;

using Tabby.Client.Command;
using Tabby.Client.Command.Message;
using Tabby.Client.Command.User;
using Tabby.Client.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client
{
    internal class Program
    {
        private static readonly ILogger _logger = new NLogLogger();
        private static readonly IMessageProcessor _messageProcessor = new MessageProcessor1();
        private static readonly IUserProcessor _userProcessor = new UserProcessor1();


        private static Guid Login(IUserProcessor userProcessor)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Guid? userId = null;
            do
            {
                try
                {
                    _logger.Info("Please, enter your NikName: ");
                    string userName = Console.ReadLine();
                    var loginCommand = new LoginUserCommand { UserProcessor = userProcessor, UserName = userName, Logger = _logger };
                    loginCommand.Execute();
                    userId = loginCommand.Result;
                }
                catch (ArgumentException)
                {
                    _logger.Error("Invalid NikName");
                }
                catch (Exception)
                {
                    _logger.Error("Error occured");
                }
            }
            while (!userId.HasValue);
            return userId.Value;
        }


        private static void Main(string[] args)
        {
            Guid userId = Login(_userProcessor);

            Console.WriteLine("Available commands:");
            Console.WriteLine("Send: Message text");
            Console.WriteLine("GetAll");
            Console.WriteLine("GetNew");

            //var timer = new MessageCheckerTimerWrapper(_messageProcessor, userId);
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
                        command.MessageProcessor = _messageProcessor;
                        command.Logger = _logger;
                        command.UserId = userId;
                        command.Execute();
                    }
                    catch (ArgumentException)
                    {
                        _logger.Error("Invalid command");
                    }
                    catch (Exception)
                    {
                        _logger.Error("Error occured");
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
