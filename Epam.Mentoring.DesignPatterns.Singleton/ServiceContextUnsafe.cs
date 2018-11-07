namespace Epam.Mentoring.DesignPatterns.Singleton
{
    internal sealed class ServiceContextUnsafe
    {
        private static ServiceContextUnsafe _context;

        private ServiceContextUnsafe()
        {
        }

        public static ServiceContextUnsafe Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new ServiceContextUnsafe();
                }

                return _context;
            }
        }
    }
}