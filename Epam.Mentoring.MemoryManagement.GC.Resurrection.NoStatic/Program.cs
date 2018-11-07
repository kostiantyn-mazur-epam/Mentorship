using System;

namespace Epam.Mentoring.MemoryManagement.GC.Resurrection.NoStatic
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Creating...");

            var subject = new Zombie("Alexandro");

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("Die already !");

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
        }
    }
}