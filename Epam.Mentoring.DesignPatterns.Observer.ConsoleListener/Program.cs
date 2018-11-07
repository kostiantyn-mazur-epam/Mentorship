using System;

namespace Epam.Mentoring.DesignPatterns.Observer.ConsoleListener
{
    public static class Program
    {
        public static void Main(string[] args)
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