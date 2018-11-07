using System;

namespace Epam.Mentoring.DesignPatterns.Observer.StockExchange.Delegates
{
    internal sealed class GoogleStockWatcher : IDisposable
    {
        private StockTicker _ticker;

        public GoogleStockWatcher(StockTicker ticker)
        {
            _ticker = ticker;
            _ticker.Notify += Update;
        }

        private void Update(Stock value)
        {
            if (value.Symbol == "GOOG")
            {
                Console.WriteLine("Google's new price is: {0}", value.Price);
            }
        }

        public void Dispose()
        {
            _ticker.Notify -= Update;
        }
    }
}