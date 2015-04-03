using System;


namespace Tabby.Terminal
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
