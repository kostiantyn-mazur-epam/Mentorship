using System;
using System.Collections.Generic;

namespace DeadAlive
{
    internal class Program
    {
        public static ICollection<object> _pool = new HashSet<object>();

        private static void Main(string[] args)
        {
            Console.WriteLine("The magic begins..");

            var zombie = new DeadAlive(_pool);
            _pool.Add(zombie);

            for (var i = 0; i < 5; i++)
            {
                if (_pool.Count > 0)
                {
                    _pool.Clear();

                    Console.WriteLine("It's dead !");
                    Console.WriteLine();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
}
