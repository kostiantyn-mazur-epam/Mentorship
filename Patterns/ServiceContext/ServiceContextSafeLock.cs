namespace ServiceContext.Lock
{
    internal sealed class ServiceContextSafeLock
    {
        private static volatile ServiceContextSafeLock _context;
        private static readonly object _syncRoot = new object();

        private ServiceContextSafeLock()
        {
        }

        public static ServiceContextSafeLock Instance
        {
            get
            {
                if (_context == null)
                {
                    lock (_syncRoot)
                    {
                        if (_context == null)
                        {
                            _context = new ServiceContextSafeLock();
                        }
                    }
                }

                return _context;
            }
        }
    }
}