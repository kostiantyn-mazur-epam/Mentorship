using System;

namespace StockExchange.Delegates
{
    internal sealed class StockTicker
    {
        private Stock _stock;

        public Stock Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;
                NotifyChange(_stock);
            }
        }

        public void NotifyChange(Stock stock)
        {
            Notify?.Invoke(stock);
        }

        public Action<Stock> Notify;
    }
}
