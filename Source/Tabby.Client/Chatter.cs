﻿using System;

using Microsoft.Practices.Unity;

using Tabby.Client.Checker;
using Tabby.Client.Command;
using Tabby.Client.Command.MessageModule;
using Tabby.Client.Command.UserModule;
using Tabby.Client.Logger;


namespace Tabby.Client
{
    public sealed class Chatter : IDisposable
    {
        [Dependency]
        public ILogger Logger { get; set; }


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
