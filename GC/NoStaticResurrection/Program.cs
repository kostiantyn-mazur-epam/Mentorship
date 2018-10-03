using System;

namespace NoStaticResurrection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating...");

            var subject = new Zombie("Alexandro");

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("Die already !");

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
