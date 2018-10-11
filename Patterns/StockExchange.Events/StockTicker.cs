using System;

namespace StockExchange.Events
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

                OnStockChange(new StockChangeEventArgs(_stock));
            }
        }

        public void OnStockChange(StockChangeEventArgs e)
        {
            StockChange?.Invoke(this, e);
        }

        public event EventHandler<StockChangeEventArgs> StockChange;
    }
}
