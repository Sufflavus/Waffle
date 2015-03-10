using System;


namespace Tabby.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var chatter = Bootstrapper.Resolve<Chatter>();
            chatter.Start();
            chatter.Dispose();
        }
    }
}
