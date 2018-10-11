using System;

namespace StockExchange.Events
{
    internal sealed class MsStockWatcher : IDisposable
    {
        private StockTicker _ticker;

        public MsStockWatcher(StockTicker ticker)
        {
            _ticker = ticker;
            _ticker.StockChange += new EventHandler<StockChangeEventArgs>(Update);
        }

        private void Update(object sender, StockChangeEventArgs e)
        {
            if (e.Symbol == "MSFT" && e.Price > 10.0m)
            {
                Console.WriteLine("Microsoft has reached the target price: {0}", e.Price);
            }
        }

        public void Dispose()
        {
            _ticker.StockChange -= Update;
        }
    }
}
