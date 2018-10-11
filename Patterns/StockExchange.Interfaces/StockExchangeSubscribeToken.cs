using System;

namespace StockExchange.Interfaces
{
    internal sealed class StockExchangeSubscribeToken : IDisposable
    {
        private StockTicker _stockTicker;
        private IObserver<Stock> _observer;

        public StockExchangeSubscribeToken(StockTicker stockTicker, IObserver<Stock> observer)
        {
            if (stockTicker == null)
            {
                throw new ArgumentNullException(nameof(stockTicker), "No stock ticker");
            }

            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer), "No observer");
            }

            _stockTicker = stockTicker;
            _observer = observer;
        }

        public void Dispose()
        {
            _stockTicker.Unsubscribe(_observer);
        }
    }
}