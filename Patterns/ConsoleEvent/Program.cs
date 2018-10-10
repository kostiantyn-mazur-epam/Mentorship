using System;

namespace ConsoleEvent
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Time to write something to console");

            var listener = new ConsoleEventListener();
            listener.Quit += ShowMessage;

            for (var i = 0; i < 5; i++)
            {
                if (Console.ReadLine() == "quit")
                {
                    listener.Raise();
                }
            }
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
