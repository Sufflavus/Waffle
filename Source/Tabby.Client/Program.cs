using System;

using Tabby.Client.Command;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
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

            //timer.Stop();
        }
    }
}
