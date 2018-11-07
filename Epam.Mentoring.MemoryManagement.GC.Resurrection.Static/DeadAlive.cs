using System;
using System.Collections.Generic;

namespace Epam.Mentoring.MemoryManagement.GC.Resurrection.Static
{
    internal sealed class DeadAlive
    {
        private readonly ICollection<object> _pool;

        internal DeadAlive(ICollection<object> pool)
        {
            _pool = pool;
            _pool.Add(this);
        }

        ~DeadAlive()
        {
            Console.WriteLine("Resurrecting...");

            _pool.Add(this);

            Console.WriteLine("Resurrected !");
            Console.WriteLine();

            System.GC.ReRegisterForFinalize(this);
        }
    }
}