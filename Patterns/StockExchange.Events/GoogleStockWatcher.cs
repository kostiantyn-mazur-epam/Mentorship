using System;

namespace StockExchange.Events
{
    internal sealed class GoogleStockWatcher : IDisposable
    {
        private StockTicker _ticker;

        public GoogleStockWatcher(StockTicker ticker)
        {
            _ticker = ticker;
            _ticker.StockChange += new EventHandler<StockChangeEventArgs>(Update);
        }

        private void Update(object sender, StockChangeEventArgs e)
        {
            if (e.Symbol == "GOOG")
            {
                Console.WriteLine("Google's new price is: {0}", e.Price);
            }
        }

        public void Dispose()
        {
            _ticker.StockChange -= Update;
        }
    }
}
