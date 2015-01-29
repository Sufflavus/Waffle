using System;


namespace Tabby.Client
{
    public class ConsoleWrapper
    {
        public static void WriteError(string errorText)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Invalid command");
            Console.WriteLine();
            Console.ForegroundColor = foregroundColor;
        }


        public static void WriteOperationResult(string text)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ForegroundColor = foregroundColor;
        }
    }
}
