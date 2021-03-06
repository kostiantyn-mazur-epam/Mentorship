﻿using System.Threading;

namespace Epam.Mentoring.DesignPatterns.Singleton
{
    internal sealed class ServiceContextSafeNoLock
    {
        private static ServiceContextSafeNoLock _context;

        private ServiceContextSafeNoLock()
        {
        }

        public static ServiceContextSafeNoLock Instance
        {
            get
            {
                if (_context == null)
                {
                    var instance = new ServiceContextSafeNoLock();

                    Interlocked.CompareExchange(ref _context, instance, null);
                }

                return _context;
            }
        }
    }
}