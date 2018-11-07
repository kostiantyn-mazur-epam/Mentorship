using System;

namespace Epam.Mentoring.DesignPatterns.Observer.StockExchange.Delegates
{
    internal sealed class MsStockWatcher : IDisposable
    {
        private StockTicker _ticker;

        public MsStockWatcher(StockTicker ticker)
        {
            _ticker = ticker;
            _ticker.Notify += Update;
        }

        private void Update(Stock value)
        {
            if (value.Symbol == "MSFT" && value.Price > 10.0m)
            {
                Console.WriteLine("Microsoft has reached the target price: {0}", value.Price);
            }
        }

        public void Dispose()
        {
            _ticker.Notify -= Update;
        }
    }
}