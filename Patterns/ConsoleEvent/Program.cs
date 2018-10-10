using System;

namespace ConsoleEvent
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Time to write something to console");

            var watcher = new ConsoleQuitMessageSource ();
            var listener = new ConsoleQuitMessageListener();
            listener.Subscribe(watcher);

            watcher.WatchConsole();
            watcher.Stop();
        }
    }
}
