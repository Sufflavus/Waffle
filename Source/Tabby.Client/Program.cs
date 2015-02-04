using System;

using Tabby.Client.Command;
using Tabby.Client.Command.Message;
using Tabby.Client.Command.User;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUserProcessor userProcessor = new UserProcessor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, enter your NikName:");
            string userName = Console.ReadLine();
            var loginCommand = new LoginUserCommand { UserProcessor = userProcessor, UserName = userName };
            loginCommand.Execute();
            Guid userId = loginCommand.Result;

            Console.WriteLine("Available commands:");
            Console.WriteLine("Send: Message text");
            Console.WriteLine("GetAll");
            Console.WriteLine("GetNew");
            Console.WriteLine();

            IMessageProcessor messageProcessor = new MessageProcessor();
            //var timer = new MessageCheckerTimerWrapper(messageProcessor);
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
                        command.MessageProcessor = messageProcessor;
                        command.UserId = userId;
                        command.Execute();
                    }
                    catch (ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Invalid command");
                        Console.WriteLine();
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("При выполнении произошла ошибка");
                        Console.WriteLine();
                    }
                }
            }
            while (hasCommand);

            var logoutCommand = new LogoutUserCommand { UserProcessor = userProcessor, UserId = userId };
            logoutCommand.Execute();

            //timer.Stop();
        }
    }
}
