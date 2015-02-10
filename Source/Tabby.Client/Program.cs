using System;

using Tabby.Client.Checker;
using Tabby.Client.Command;
using Tabby.Client.Command.Message;
using Tabby.Client.Command.User;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Client
{
    internal class Program
    {
        private static readonly IMessageProcessor _messageProcessor = new MessageProcessor();
        private static readonly IUserProcessor _userProcessor = new UserProcessor();


        private static Guid Login(IUserProcessor userProcessor)
        {
            Guid? userId = null;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please, enter your NikName: ");
                    string userName = Console.ReadLine();
                    var loginCommand = new LoginUserCommand { UserProcessor = userProcessor, UserName = userName };
                    loginCommand.Execute();
                    userId = loginCommand.Result;
                }
                catch (ArgumentException)
                {
                    ConsoleWrapper.WriteError("Invalid NikName");
                }
                catch (Exception)
                {
                    ConsoleWrapper.WriteError("Error occured");
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
            Console.WriteLine();

            var timer = new MessageCheckerTimerWrapper(_messageProcessor, userId);
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
                        command.MessageProcessor = _messageProcessor;
                        command.UserId = userId;
                        command.Execute();
                    }
                    catch (ArgumentException)
                    {
                        ConsoleWrapper.WriteError("Invalid command");
                    }
                    catch (Exception)
                    {
                        ConsoleWrapper.WriteError("Error occured");
                    }
                }
            }
            while (hasCommand);

            var logoutCommand = new LogoutUserCommand { UserProcessor = _userProcessor, UserId = userId };
            logoutCommand.Execute();

            timer.Stop();
        }
    }
}
