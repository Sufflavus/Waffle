using System;

using Tabby.Client.Command;

using Taddy.BusinessLogic;


namespace Tabby.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Чтобы отправить сообщение, наберите сообщение и нажмите Enter");
            Console.WriteLine("Чтобы выйти, нажмите Enter");
            Console.WriteLine();

            IMessageProcessor messageProcessor = new MessageProcessor();
            var timer = new MessageCheckerTimerWrapper(messageProcessor);
            timer.Start();

            bool hasCommand;
            do
            {
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
                        Console.WriteLine("Неверная команда");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("При выполнении произошла ошибка");
                    }
                }
            }
            while (hasCommand);

            timer.Stop();
        }
    }
}
