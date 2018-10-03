﻿using System;

namespace NoStaticResurrection
{
    internal class Zombie
    {
        private string _payload;

        public Zombie(string payload)
        {
            _payload = payload;

            Console.WriteLine("{0} created", _payload);
            Console.WriteLine();
        }

        ~Zombie()
        {
            Console.WriteLine("Resurrecting {1}, object {0}..", GetHashCode(), _payload);

            GC.ReRegisterForFinalize(this);

            Console.WriteLine("Resurrected {0} !", _payload);
            Console.WriteLine();
        }
    }
}
